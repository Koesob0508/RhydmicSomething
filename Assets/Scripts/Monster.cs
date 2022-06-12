using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : Character
{
    private MonsterController monsterController;

    private Vector3 moveDirection;

    void Start()
    {
        monsterController = GetComponent<MonsterController>();
        this.characterRigidbody = GetComponent<Rigidbody>();
        this.characterAnimator = GetComponent<Animator>();

        this.health = this.maxHealth;
    }

    // void FixedUpdate()
    // {
    //     // this.characterAnimator.SetFloat("Move", moveDirection.magnitude);    
    // }

    public override void Move(Vector2 _direction)
    {
        moveDirection = (Vector3.right * _direction.x) + (Vector3.forward * _direction.y);
        Vector3 moveDistance = moveDirection.normalized * moveSpeed * Time.deltaTime;
        if (!(_direction.x == 0 && _direction.y == 0))
        {
            this.characterRigidbody.MovePosition(this.characterRigidbody.position + moveDistance);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(moveDirection), Time.deltaTime * rotateSpeed);
        }
    }

    public override void Attack()
    {
        // this.characterAnimator.SetTrigger("Attack");
    }
}
