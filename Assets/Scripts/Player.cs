using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    private TestPlayerController playerController;

    private Vector3 moveDirection;

    void Start()
    {
        playerController = GetComponent<TestPlayerController>();
        this.characterRigidbody = GetComponent<Rigidbody>();
        this.characterAnimator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        Move();

        this.characterAnimator.SetFloat("Move", moveDirection.magnitude);

        // if (playerController.attack)
        // {
        //     this.characterAnimator.SetTrigger("Attack");
        // }
    }

    public override void Move()
    {
        moveDirection = (Vector3.forward * playerController.verticalMove) + (Vector3.right * playerController.horizontalMove);
        Vector3 moveDistance = moveDirection.normalized * moveSpeed * Time.deltaTime;
        if (!(playerController.horizontalMove == 0 & playerController.verticalMove == 0))
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
