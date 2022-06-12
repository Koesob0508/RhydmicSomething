using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayerController : PlayerController
{
    public string moveAxisName = "Vertical";
    public string rotateAxisName = "Horizontal";
    // 임시 방편, 왼쪽 ctrl, 마우스 왼쪽 버튼
    public string attackButtonName = "Fire1";

    public float verticalMove { get; private set; }
    public float horizontalMove { get; private set; }
    public bool attack { get; private set; }

    void Update()
    {
        verticalMove = Input.GetAxis(moveAxisName);
        horizontalMove = Input.GetAxis(rotateAxisName);
        attack = Input.GetMouseButtonUp(0);

        if (attack)
        {
            Debug.Log("실행");
            character.gameObject.GetComponent<Player>().Attack();
        }
    }
}
