using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace prototype01
{
    public abstract class P1Character : MonoBehaviour
    {
        private Vector3 moveDirection;

        [SerializeField] protected float maxHealth;
        [SerializeField] protected float health;
        [SerializeField] protected float moveSpeed;
        [SerializeField] protected float rotateSpeed;
        [SerializeField] public bool CanMove;

        [SerializeField] protected Rigidbody characterRigidbody;
        public virtual void Initialize()
        {
            this.characterRigidbody = this.gameObject.GetComponent<Rigidbody>();
        }

        public virtual void GameStart()
        {
            this.gameObject.SetActive(true);
            this.health = this.maxHealth;
        }

        public virtual void GameEnd()
        {
            this.CanMove = false;
            this.gameObject.SetActive(false);
        }

        protected virtual void Die()
        {
            this.CanMove = false;
            this.gameObject.SetActive(false);
        }

        public void Move(Vector2 _direction)
        {
            moveDirection = (Vector3.forward * _direction.x) + (Vector3.right * _direction.y);
            Vector3 moveDistance = moveDirection.normalized * moveSpeed * Time.deltaTime;
            if (this.CanMove && !(_direction.x == 0 & _direction.y == 0))
            {
                this.characterRigidbody.MovePosition(this.characterRigidbody.position + moveDistance);
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(moveDirection), Time.deltaTime * rotateSpeed);
            }
        }

        public virtual void GetDamage(float _damage)
        {
            health -= _damage;

            if(health <= 0)
            {
                Die();
            }
        }

        
    }
}


