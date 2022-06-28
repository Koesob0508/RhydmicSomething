using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Prototype02
{
    public class P2AFireBall : P2AttackRange
    {
        private SpriteRenderer sprite;
        public float moveSpeed;
        [SerializeField] private Vector2 moveDirection;

        private void FixedUpdate()
        {
            Vector2 moveDistance = moveDirection.normalized * moveSpeed * Time.fixedDeltaTime;

            this.transform.Translate(moveDistance);
        }
        public override void Initilize()
        {
            sprite = this.GetComponent<SpriteRenderer>();
            if (this.transform.rotation.z < -90 || this.transform.rotation.z > 90)
            {
                this.sprite.flipX = true;
            }
            else
            {
                this.sprite.flipX = false;
            }

            base.Initilize();
        }

        protected override IEnumerator InactiveSelf()
        {
            yield return new WaitForSeconds(P2GameManager.tempo * 3f);
            this.gameObject.SetActive(false);
        }

        public override void SetDirection(Vector2 _direction)
        {
            base.SetDirection(_direction);

            this.moveDirection = _direction;
        }
    }
}

