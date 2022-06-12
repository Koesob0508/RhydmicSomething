using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameManager gameManager;
    [SerializeField] UISheet UISheet;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public void ShowUI()
    {
        Debug.Log("Show yourself");
    }

    public void StageClear(int nextStage)
    {

    }

    public void StageFail()
    {

    }
}
