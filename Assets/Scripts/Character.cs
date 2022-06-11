using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public void Move()
    {
        Debug.Log("Move");
    }

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
