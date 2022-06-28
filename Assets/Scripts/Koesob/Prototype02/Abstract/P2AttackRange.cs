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
            if (other.CompareTag("Enemy"))
            {
                other.gameObject.GetComponent<P2Enemy>().TakeDamage(10f);
            }
        }

        public void SetDirection(Vector2 _direction)
        {
            float angle = Mathf.Acos(Vector2.Dot(Vector2.right, _direction) / _direction.magnitude) * Mathf.Rad2Deg;
            this.gameObject.transform.localPosition = Vector2.zero;
            if(_direction.y < 0)
            {
                this.gameObject.transform.rotation = Quaternion.Euler(0f, 0f, angle * -1);
            }
            else
            {
                this.gameObject.transform.rotation = Quaternion.Euler(0f, 0f, angle);
            }
        }
    }

}
