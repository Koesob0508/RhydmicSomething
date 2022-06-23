using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace prototype01
{
    public class P1JoystickInputManager : P1InputManager, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        [SerializeField]
        private RectTransform lever;
        private RectTransform rectTransform;

        [SerializeField, Range(10f, 150f)]
        private float leverRange;

        [SerializeField] private Vector2 inputDirection;
        private bool isInput;

        private void Awake()
        {
            rectTransform = GetComponent<RectTransform>();
        }

        void Update()
        {
            InputControlVector();
        }

        public override void Initialize(P1Player _player)
        {
            base.Initialize(_player);
        }
        public override void GameStart()
        {
            
        }

        public override void GameEnd()
        {
            
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
            Vector3 inputDir = eventData.position - rectTransform.anchoredPosition;
            var clampedDir = inputDir.magnitude < leverRange ? inputDir
                : inputDir.normalized * leverRange;
            lever.anchoredPosition = clampedDir;
            inputDirection = clampedDir / leverRange;
        }


        private void InputControlVector()
        {
            playerController.SetDirectionInfo(inputDirection.y, inputDirection.x);
        }

        public override void OpenFloatingUI()
        {
            this.gameObject.SetActive(false);
        }

        public override void CloseFloatingUI()
        {
            this.gameObject.SetActive(true);
        }
    }

}
