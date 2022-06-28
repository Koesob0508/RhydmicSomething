using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Prototype02
{
    public abstract class P2InputManager : MonoBehaviour
    {
        protected P2PlayerController playerController;
        [SerializeField] protected float verticalInput;
        [SerializeField] protected float horizontalInput;
        [SerializeField] protected bool isAttack;
        protected Vector2 directionInfo;

        public virtual void Initialize(P2PlayerController _playerController)
        {
            this.playerController = _playerController;
            if(this.playerController.gameObject)
            {
                Debug.Log("Input Manager Initialized");
            }
        }

        protected void GetKeyboardInput()
        {
            verticalInput = Input.GetAxisRaw("Vertical");
            horizontalInput = Input.GetAxisRaw("Horizontal");
            isAttack = Input.GetKeyDown(KeyCode.Space);
            playerController.SetDirectionInfo(horizontalInput, verticalInput);
            if(isAttack)
            {
                playerController.Action(1);
            }
        }
    }
}


