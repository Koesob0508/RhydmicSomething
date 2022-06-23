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

        public override void GameStart()
        {
            base.GameStart();
            
            this.CanMove = true;
            this.transform.position = new Vector3(0f, 2f, 0f);
            this.transform.rotation = Quaternion.identity;
        }
        
        protected override void Die()
        {
            base.Die();

            actionDie();
        }

        public void Attack()
        {
            punch.gameObject.SetActive(true);
            if(this.enabled)
            {
                StartCoroutine(this.WaitMove());
            }
        }

        IEnumerator WaitMove()
        {
            CanMove = false;
            yield return new WaitForSeconds(.5f);
            CanMove = true;
        }

    }
}


