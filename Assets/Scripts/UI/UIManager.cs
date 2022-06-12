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
        UISheet.StartSheetBuild();

        gameManager.stageManager.stageAction += SetStageStatus;
    }

    public void DoneSheetBuild()
    {
        gameManager.CompleteBuild();
    }

    public void SetStageStatus(Define.eStageStatus status)
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
                SucceedStage();
                break;
            case Define.eStageStatus.Fail:
                FailStage();
                break;
        }
    }

    void InitStage()
    {

    }

    void StartStage()
    {

    }

    void SucceedStage()
    {
        UISheet.StartSheetBuild();
    }

    void FailStage()
    {

    }
}