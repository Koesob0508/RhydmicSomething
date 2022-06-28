using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Prototype02
{
    public class P2AJoystickInputManager : P2InputManager, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        [SerializeField] private RectTransform lever;
        [SerializeField, Range(10f, 150f)] private float leverRange;
        [SerializeField] private Vector2 inputDirection;

        private RectTransform rectTransform;

        private bool isInput;

        private void Update()
        {
            InputControlVector();
        }

        public override void Initialize(P2PlayerController _playerController)
        {
            this.rectTransform = this.GetComponent<RectTransform>();

            base.Initialize(_playerController);
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            ControlJoystickLever(eventData);
            isInput = true;
        }

        public void OnDrag(PointerEventData eventData)
        {
            ControlJoystickLever(eventData);
            isInput = false;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            lever.anchoredPosition = Vector2.zero;
            inputDirection = Vector2.zero;
        }

        public void ControlJoystickLever(PointerEventData eventData)
        {
            Vector2 inputDir = eventData.position - rectTransform.anchoredPosition;
            var clampedDir = inputDir.magnitude < leverRange ? inputDir
                : inputDir.normalized * leverRange;
            lever.anchoredPosition = clampedDir;
            inputDirection = clampedDir / leverRange;
        }

        private void InputControlVector()
        {
            playerController.SetDirectionInfo(inputDirection.x, inputDirection.y);
        }
    }
}

