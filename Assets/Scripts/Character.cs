using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float rotateSpeed = 180f;

    protected Rigidbody characterRigidbody;
    protected Animator characterAnimator;

    public abstract void Move();

    public abstract void Attack();

    public void Hit(float _damage)
    {
        Debug.Log("Hit "+ _damage);
    }

    public void Heal(float _heal)
    {
        Debug.Log("Heal " + _heal);
    }

    public void Die()
    {
        Debug.Log("Die");
    }
}
