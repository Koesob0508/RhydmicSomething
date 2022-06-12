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

    public void Act()
    {
        
    }

    public void Move(Vector2 vector2)
    {
        player.Move(vector2);
    }

    public override void Attack()
    {
        throw new System.NotImplementedException();
    }
}
