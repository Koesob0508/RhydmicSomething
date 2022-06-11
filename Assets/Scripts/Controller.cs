using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    private Character pawn;

    public void SetPawn(Character _pawn)
    {
        pawn = _pawn;
    }
}
