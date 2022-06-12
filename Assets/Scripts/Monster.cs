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
    }

    void FixedUpdate()
    {
        Move();

        this.characterAnimator.SetFloat("Move", moveDirection.magnitude);    
    }

    public override void Move()
    {
        moveDirection = (Vector3.forward * monsterController.verticalMove) + (Vector3.right * monsterController.horizontalMove);
        Vector3 moveDistance = moveDirection.normalized * moveSpeed * Time.deltaTime;
        if (!(monsterController.horizontalMove == 0 & monsterController.verticalMove == 0))
        {
            this.characterRigidbody.MovePosition(this.characterRigidbody.position + moveDistance);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(moveDirection), Time.deltaTime * rotateSpeed);
        }
    }

    public override void Attack()
    {
        this.characterAnimator.SetTrigger("Attack");
    }
}
