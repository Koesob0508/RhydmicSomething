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
}
