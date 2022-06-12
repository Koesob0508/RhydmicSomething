using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public GameManager gameManager;
    [SerializeField] UISheet UISheet;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    public void StageClear(int nextStage)
    {

    }

    public void StageFail()
    {

    }

    public void StartSheetBuild()
    {
        UISheet.StartSheetBuild();
    }

    public void DoneSheetBuild()
    {
        gameManager.CompleteBuild();
    }
}
