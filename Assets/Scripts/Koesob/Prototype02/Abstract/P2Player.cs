using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Prototype02
{
    public abstract class P2Player : P2Character
    {
        public UnityAction actionDie;
        [SerializeField] protected P2AttackRange arrowSword;

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
            arrowSword.gameObject.SetActive(true);
            if(this.enabled)
            {
                StartCoroutine(this.WaitMove());
            }
        }

        protected IEnumerator WaitMove()
        {
            this.canMove = false;
            yield return new WaitForSeconds(P2GameManager.tempo);
            this.canMove = true;
        }
    }
}