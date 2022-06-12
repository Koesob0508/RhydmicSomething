using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : Controller
{
    public float verticalMove { get; private set; }
    public float horizontalMove { get; private set; }
    public bool attack { get; private set; }
}
