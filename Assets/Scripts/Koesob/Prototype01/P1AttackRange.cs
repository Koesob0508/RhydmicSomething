using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace prototype01
{
    public class P1AttackRange : MonoBehaviour
    {
        private void OnEnable()
        {
            StartCoroutine(SelfInactive());
        }

        IEnumerator SelfInactive()
        {
            yield return new WaitForSeconds(.5f);
            this.gameObject.SetActive(false);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Enemy"))
            {
                other.gameObject.GetComponent<P1Enemy>().GetDamage(10f);
            }
        }
    }
}


