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
        StartSheetBuild();

        gameManager.stageManager.stageAction += Stage;
    }

    public void StageSucceeded(int nextStage)
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

    public void Stage(Define.eStageStatus status)
    {
        switch (status)
        {
            case Define.eStageStatus.none:

                break;
            case Define.eStageStatus.Init:
                InitStage();
                break;
            case Define.eStageStatus.Start:
                StartStage();
                break;
            case Define.eStageStatus.Succeed:
                break;
            case Define.eStageStatus.Fail:
                break;
        }
    }

    public void InitStage()
    {

    }

    public void StartStage()
    {

    }
}
