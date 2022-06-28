using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Prototype02
{
    public abstract class P2PlayerController : P2Controller
    {
        protected Vector2 direction;
        protected P2Player player;

        private void FixedUpdate()
        {
            player.Move(direction);
        }

        public void Initialize()
        {
            this.player = this.gameObject.GetComponent<P2Player>();
        }

        public void SetDirectionInfo(float _verticalInput, float _horizontlaInput)
        {
            direction.x = _verticalInput;
            direction.y = _horizontlaInput;
        }

        public void Action(int _actionNumber)
        {
            switch(_actionNumber)
            {
                case 1:
                    this.player.Attack();
                    break;

                default:
                    break;
            }
        }
    }

}
