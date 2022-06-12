using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : Controller
{
    public float verticalMove { get; private set; }
    public float horizontalMove { get; private set; }
    public bool attack { get; private set; }
    public Player target;
    private Vector3 direction;
    private Vector2 surfaceDirection;
    private float distance;
    public float threshold;
    private bool isAttack;
    void Start()
    {
        this.SetCharacter(this.gameObject.GetComponent<Monster>());
    }

    void Update()
    {

        // target position으로 다가간다. Move
        // 방향 벡터를 구한다.
        direction = target.transform.position - this.transform.position;
        distance = direction.magnitude;
        if (distance > threshold && !isAttack)
        {
            surfaceDirection = new Vector2(direction.x, direction.z);
            // 노멀라이즈를 한다.
            // 그 방향으로 이동한다.
            character.Move(surfaceDirection.normalized);
        }
        else if(!isAttack)
        {
            // 일정 거리 내에 들어오면 공격
            StartCoroutine(StartAttack());
        }
    }

    public void SetTarget(Player _player)
    {
        this.target = _player;
    }

    IEnumerator StartAttack()
    {
        isAttack = true;
        character.Attack();
        Debug.Log("Monster Attack");
        yield return new WaitForSeconds(1f);
        isAttack = false;
    }

    public override void Attack()
    {
        throw new System.NotImplementedException();
    }
}
