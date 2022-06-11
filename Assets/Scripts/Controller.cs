using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    protected Character character;

    public void SetCharacter(Character _character)
    {
        character = _character;
        Debug.Log("아쟁이 소리가 들린다");
    }
}
