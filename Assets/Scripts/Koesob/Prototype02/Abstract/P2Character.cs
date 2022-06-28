using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Prototype02
{
    public abstract class P2Character : MonoBehaviour
    {
        [SerializeField] protected float maxHealth;
        [SerializeField] protected float currentHealth;
        [SerializeField] protected float moveSpeed;
        [SerializeField] protected Vector2 moveDirection;
        [SerializeField] public bool canMove;

        protected Rigidbody2D characterRigidbody;
        protected SpriteRenderer sprite;

        public bool isRigidbody;
        public bool isSprite;

        public virtual void Initialize()
        {
            this.characterRigidbody = this.gameObject.GetComponent<Rigidbody2D>();
            this.sprite = this.gameObject.GetComponent<SpriteRenderer>();

            if(characterRigidbody)
            {
                this.isRigidbody = true;
            }

            if(sprite)
            {
                this.isSprite = true;
            }
        }

        public virtual void StartGame()
        {
            this.gameObject.SetActive(true);
            this.canMove = true;
            this.currentHealth = this.maxHealth;
        }
        public virtual void EndGame()
        {
            this.canMove = false;
            this.gameObject.SetActive(false);
        }

        protected virtual void Die()
        {
            this.EndGame();
        }

        public virtual void Move(Vector2 _direction)
        {
            moveDirection = (Vector2.right * _direction.x) + (Vector2.up * _direction.y);
            Vector2 moveDistance = moveDirection.normalized * moveSpeed * Time.fixedDeltaTime;
            if (this.canMove && !(_direction.x == 0 & _direction.y == 0))
            {
                this.characterRigidbody.MovePosition(this.characterRigidbody.position + moveDistance);
                // transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(moveDirection), Time.fixedDeltaTime * rotateSpeed);
                
                if(_direction.x < 0)
                {
                    // this.gameObject.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                    this.sprite.flipX = false;
                }
                else if(_direction.x > 0)
                {
                    // this.gameObject.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
                    this.sprite.flipX = true;
                }
                
            }
        }

        public virtual void TakeDamage(float _damage)
        {
            currentHealth -= _damage;

            if(currentHealth <= 0f)
            {
                this.Die();
            }
        }
    }
}


