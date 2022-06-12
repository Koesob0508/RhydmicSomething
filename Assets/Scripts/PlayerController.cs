using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Controller
{
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public void Act()
    {
        
    }
}
