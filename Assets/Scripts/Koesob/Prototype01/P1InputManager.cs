using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace prototype01
{
    public class P1InputManager : MonoBehaviour
    {
        protected P1PlayerController playerController;
        [SerializeField] protected float verticalInput;
        [SerializeField] protected float horizontalInput;
        protected Vector2 directionInfo;
        private bool CanKeyboardInput;
        private bool CanMouseInput;

        // Update is called once per frame
        //void Update()
        //{
        //    if (CanKeyboardInput)
        //    {
        //        this.GetKeyboardInput();
        //    }
        //}

        public virtual void Initialize(P1Player _player)
        {
            this.playerController = _player.gameObject.GetComponent<P1PlayerController>();
            if (this.playerController.gameObject)
            {
                Debug.Log("Input Manager Player Controller Setting Complete");
            }
        }

        public virtual void GameStart()
        {
            Debug.Log("조이스틱 사용 중");
            this.SetKeyboardInput(true);
            this.SetMousedInput(false);
        }

        public virtual void GameEnd()
        {

        }

        public virtual void OpenFloatingUI()
        {
            Debug.Log("조이스틱 사용 중");
            this.SetKeyboardInput(false);
            this.SetMousedInput(true);
        }

        public virtual void CloseFloatingUI()
        {
            Debug.Log("조이스틱 사용 중");
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