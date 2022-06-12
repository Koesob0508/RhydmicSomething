using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Controller : MonoBehaviour
{
    protected Character character;

    public void SetCharacter(Character _character)
    {
        character = _character;
    }

    public abstract void Attack();
}
