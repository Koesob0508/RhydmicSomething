using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Prototype02
{
    public abstract class P2Player : P2Character
    {
        public UnityAction actionDie;

        [SerializeField] protected Vector2 fowardDirection;
        [SerializeField] protected P2AttackRange arrowSword;
        [SerializeField] protected P2AttackRange fireBall;

        public override void StartGame()
        {
            base.StartGame();

            this.transform.position = new Vector2(0f, 0f);
            this.transform.rotation = Quaternion.identity;
        }

        protected override void Die()
        {
            base.Die();

            actionDie();
        }

        public void Attack()
        {
            this.fowardDirection = this.SetFowardDirection(this.moveDirection);

            arrowSword.gameObject.SetActive(true);
            arrowSword.Initilize();
            arrowSword.SetDirection(this.fowardDirection);

            if (this.enabled)
            {
                StartCoroutine(this.WaitMove());
            }
        }

        public void FireBall()
        {
            this.fowardDirection = this.SetFowardDirection(this.moveDirection);

            fireBall.gameObject.SetActive(true);
            fireBall.Initilize();
            fireBall.SetDirection(this.fowardDirection);
        }

        public void Dash()
        {
            //dash.gameObject.SetActive(true);

            StartCoroutine(this.StartDash());

            if (this.enabled)
            {
                StartCoroutine(this.WaitMove());
            }
        }

        private IEnumerator StartDash()
        {
            this.fowardDirection = this.SetFowardDirection(this.moveDirection);

            Vector2 targetPosition = this.characterRigidbody.position + fowardDirection * this.moveSpeed;

            for (float dashTime = P2GameManager.tempo * 0.75f; dashTime >= 0; dashTime -= Time.fixedDeltaTime)
            {
                Vector2 dashPosition = Vector2.Lerp(this.characterRigidbody.position, targetPosition, .5f);

                this.characterRigidbody.MovePosition(dashPosition);

                yield return new WaitForSeconds(Time.fixedDeltaTime);
            }
        }

        protected IEnumerator WaitMove()
        {
            this.canMove = false;
            yield return new WaitForSeconds(P2GameManager.tempo);
            this.canMove = true;
        }

        protected Vector2 SetFowardDirection(Vector2 _moveDirection)
        {
            Vector2 resultDirection = _moveDirection;

            if (_moveDirection.magnitude == 0)
            {
                if (this.sprite.flipX)
                {
                    // 오른쪽 바라보고 있음
                    resultDirection = Vector2.right;
                }
                else
                {
                    // 왼쪽 바라보고 있음
                    resultDirection = Vector2.left;
                }
            }

            return resultDirection;
        }
    }
}