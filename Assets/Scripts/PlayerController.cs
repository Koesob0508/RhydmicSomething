using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Controller
{
    public Player player;
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);

        this.SetCharacter(player);
    }

    public void Move(Vector2 vector2)
    {
        player.Move(vector2);
    }

    public void Attack()
    {
        player.Attack();
    }

    public void Dash()
    {
        player.Dash();
    }

    public void Heal()
    {
        player.Heal(10);
    }
}
