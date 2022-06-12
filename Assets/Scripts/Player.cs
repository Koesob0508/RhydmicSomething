using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    public float moveSpeed = 1f;
    public float rotateSpeed = 180f;
    private TestPlayerController playerController;
    private Rigidbody playerRigidbody;
    private Animator playerAnimator;
    private Vector3 moveDirection;

    void Start()
    {
        playerController = GetComponent<TestPlayerController>();
        playerRigidbody = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        Move();

        playerAnimator.SetFloat("Move", moveDirection.magnitude);
    }

    new private void Move()
    {
        moveDirection = (Vector3.forward * playerController.verticalMove) + (Vector3.right * playerController.horizontalMove);
        Vector3 moveDistance = moveDirection.normalized * moveSpeed * Time.deltaTime;
        if (!(playerController.horizontalMove == 0 & playerController.verticalMove == 0))
        {
            playerRigidbody.MovePosition(playerRigidbody.position + moveDistance);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(moveDirection), Time.deltaTime * rotateSpeed);
        }
    }
}
