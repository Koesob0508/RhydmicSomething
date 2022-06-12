using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackRange : MonoBehaviour
{
    public Player player;
    public float delayTime;

    void OnEnable()
    {
        StartCoroutine(this.SelfDisable());
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<Monster>().Hit(player.attackDamage);
        }
    }

    IEnumerator SelfDisable()
    {
        yield return new WaitForSeconds(delayTime);
        this.gameObject.SetActive(false);
    }
}
