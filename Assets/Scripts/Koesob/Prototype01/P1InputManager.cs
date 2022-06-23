using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace prototype01
{
    public class P1InputManager : MonoBehaviour
    {
        private P1PlayerController playerController;
        [SerializeField] private float verticalInput;
        [SerializeField] private float horizontalInput;
        private Vector2 directionInfo;
        private bool CanKeyboardInput;
        private bool CanMouseInput;

        // Update is called once per frame
        void Update()
        {
            if (CanKeyboardInput)
            {
                this.GetKeyboardInput();
            }
        }

        public void Initialize(P1Player _player)
        {
            this.playerController = _player.gameObject.GetComponent<P1PlayerController>();
            if (this.playerController.gameObject)
            {
                Debug.Log("Input Manager Player Controller Setting Complete");
            }
        }

        public void GameStart()
        {
            this.SetKeyboardInput(true);
            this.SetMousedInput(false);

        }

        public void GameEnd()
        {

        }

        public void OpenUI()
        {
            this.SetKeyboardInput(false);
            this.SetMousedInput(true);
        }

        public void CloseUI()
        {
            this.SetKeyboardInput(true);
            this.SetMousedInput(false);
        }

        private void SetKeyboardInput(bool _value)
        {
            if (_value)
            {
                this.CanKeyboardInput = true;
            }
            else
            {
                this.CanKeyboardInput = false;
            }
        }

        private void GetKeyboardInput()
        {
            verticalInput = Input.GetAxisRaw("Vertical");
            horizontalInput = Input.GetAxisRaw("Horizontal");
            playerController.SetDirectionInfo(verticalInput, horizontalInput);
        }

        private void SetMousedInput(bool _value)
        {
            if (_value)
            {
                this.CanMouseInput = true;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            else
            {
                this.CanMouseInput = false;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }
    }
}