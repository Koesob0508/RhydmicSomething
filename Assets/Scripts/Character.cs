using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float rotateSpeed = 180f;
    public float maxHealth;
    public float health;
    public float attackDamage;

    protected Rigidbody characterRigidbody;
    protected Animator characterAnimator;

    public abstract void Move(Vector3 _direction);

    public abstract void Attack();

    public void Hit(float _damage)
    {
        if(health < _damage)
        {
            this.Die();
        }
        else
        {
            health -= _damage;
        }
    }

    public void Heal(float _heal)
    {
        Debug.Log("Heal " + _heal);

        if(this.maxHealth < this.health + _heal)
        {
            this.health = this.maxHealth;
        }
        else
        {
            this.health += _heal;
        }

    }

    public void Die()
    {
        Debug.Log(this.name + " Die");

        this.gameObject.SetActive(false);
    }
}
