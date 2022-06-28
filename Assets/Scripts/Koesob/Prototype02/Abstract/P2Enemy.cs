using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Prototype02
{
    public abstract class P2Enemy : P2Character
    {
        public UnityAction<bool, GameObject> actionInactive;

        protected void OnTriggerEnter2D(Collider2D other)
        {
            if(other.CompareTag("Player"))
            {
                other.gameObject.GetComponent<P2Player>().TakeDamage(10f);

                this.Die();
            }
        }

        protected override void Die()
        {
            base.Die();

            actionInactive(true, this.gameObject);
        }

        protected void Suicide()
        {
            base.Die();

            actionInactive(false, this.gameObject);
        }
    }
}

