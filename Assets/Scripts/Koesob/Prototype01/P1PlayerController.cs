using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace prototype01
{
    public class P1PlayerController : MonoBehaviour
    {
        private Vector2 direction;
        private P1Player player;

        private void FixedUpdate()
        {
            player.Move(direction);
        }

        public void Initialize()
        {
            this.player = this.gameObject.GetComponent<P1Player>();
        }


        public void SetDirectionInfo(float _verticalInput, float _horizontlaInput)
        {
            direction.x = _verticalInput;
            direction.y = _horizontlaInput;
        }

        public void Action(int _actionNumber)
        {
            if(_actionNumber == 1)
            {
                this.player.PunchAttack();
            }
            else if(_actionNumber == 2)
            {
                this.player.Dash();
            }
        }
    }
}

