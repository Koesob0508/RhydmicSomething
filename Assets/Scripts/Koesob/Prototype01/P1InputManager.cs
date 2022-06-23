using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace prototype01
{
    public class P1InputManager : MonoBehaviour
    {
        private P1PlayerController playerController;
        private float verticalInput;
        private float horizontalInput;
        private Vector2 directionInfo;

        // Update is called once per frame
        void Update()
        {
            verticalInput = Input.GetAxis("Vertical");
            horizontalInput = Input.GetAxis("Horizontal");
            playerController.SetDirectionInfo(verticalInput, horizontalInput);
            if(Input.GetKeyDown(KeyCode.Space))
            {
                playerController.Action(1);
            }
        }

        public void Initialize(P1Player _player)
        {
            this.playerController = _player.gameObject.GetComponent<P1PlayerController>();
            if(this.playerController.gameObject)
            {
                Debug.Log("Input Manager Player Controller Setting Complete");
            }
        }
    }
}