using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace prototype01
{
    public class P1Enemy : P1Character
    {
        public UnityAction<bool, GameObject> actionInactive;

        public override void GameStart()
        {
            base.GameStart();
            StartCoroutine(WaitForSpawn());
        }

        protected override void Die()
        {
            base.Die();

            actionInactive(true, this.gameObject);
        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.CompareTag("Player"))
            {
                other.gameObject.GetComponent<P1Player>().GetDamage(10);

                this.Suicide();
            }
        }

        private void Suicide()
        {
            this.CanMove = false;
            this.gameObject.SetActive(false);

            actionInactive(false, this.gameObject);
        }

        private IEnumerator WaitForSpawn()
        {
            this.CanMove = false;
            yield return new WaitForSeconds(1.0f);
            this.CanMove = true;
        }
    }
}


