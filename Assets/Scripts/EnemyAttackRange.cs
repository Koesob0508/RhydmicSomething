using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackRange : MonoBehaviour
{
    public Monster monster;
    public float delayTime;

    void OnEnable()
    {
        StartCoroutine(this.SelfDisable());
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Player>().Hit(monster.attackDamage);
        }
    }

    IEnumerator SelfDisable()
    {
        yield return new WaitForSeconds(delayTime);
        this.gameObject.SetActive(false);
    }
}
