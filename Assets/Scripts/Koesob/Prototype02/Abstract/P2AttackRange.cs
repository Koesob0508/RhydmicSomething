using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Prototype02
{
    public abstract class P2AttackRange : MonoBehaviour
    {
        private void OnEnable()
        {
            StartCoroutine(InactiveSelf());
        }

        IEnumerator InactiveSelf()
        {
            yield return new WaitForSeconds(P2GameManager.tempo * 0.75f);
            this.gameObject.SetActive(false);
        }

        protected void OnTriggerEnter2D(Collider2D other)
        {
            if(other.CompareTag("Enemy"))
            {
                other.gameObject.GetComponent<P2Enemy>().TakeDamage(10f);
            }
        }
    }

}
