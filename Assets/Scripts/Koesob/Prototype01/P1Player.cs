using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace prototype01
{
    public class P1Player : P1Character
    {
        public UnityAction actionDie;
        [SerializeField] private P1AttackRange punch;
        [SerializeField] private P1AttackRange dash;

        public override void GameStart()
        {
            base.GameStart();

            this.CanMove = true;
            this.transform.position = new Vector3(0f, 0.5f, 0f);
            this.transform.rotation = Quaternion.identity;
        }

        protected override void Die()
        {
            base.Die();

            actionDie();
        }

        public void PunchAttack()
        {
            punch.gameObject.SetActive(true);
            if (this.enabled)
            {
                StartCoroutine(this.WaitMove());
            }
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
            Vector3 targetPosition = this.characterRigidbody.position + this.transform.forward * this.moveSpeed;

            for (float dashTime = 0.3f; dashTime >= 0; dashTime -= Time.fixedDeltaTime)
            {
                Vector3 dashPosition = Vector3.Lerp(this.characterRigidbody.position, targetPosition, .5f);

                this.characterRigidbody.MovePosition(dashPosition);

                yield return new WaitForSeconds(Time.fixedDeltaTime);
            }
        }

        private IEnumerator WaitMove()
        {
            CanMove = false;
            yield return new WaitForSeconds(.4f);
            CanMove = true;
        }

    }
}


