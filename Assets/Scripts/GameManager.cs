using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public StageManager stageManager;

    public int stageStep;

    void Start()
    {
        instance = this;
        DontDestroyOnLoad(this.gameObject);
        UIManager.instance.StartSheetBuild();

        stageManager.stageAction += StageChanged;
    }

    /// <summary>
    /// UI 로부터 받음
    /// </summary>
    public void CompleteBuild()
    {
        Debug.Log("GameManager received complete sheet build");
        // SceneManager.LoadScene("StageScene"); 확인 동안 MainScene에서만 작업합니다.
        this.stageManager.GenerateStage(stageStep);
    }

    private void StageChanged(Define.eStageStatus status)
    {
        switch (status)
        {
            case Define.eStageStatus.none:
                break;
            case Define.eStageStatus.Init:
                break;
            case Define.eStageStatus.Start:
                break;
            case Define.eStageStatus.Succeed:
                Succeeded();
                break;
            case Define.eStageStatus.Fail:
                Failed();
                break;
        }
    }

    void Failed()
    {
        Debug.Log("Stage Failed");
        // SceneManager.LoadScene("MainScene");
    }

    void Succeeded()
    {
        Debug.Log("Stage Succeeded");
        stageStep++;
        // SceneManager.LoadScene("MainScene");
    }

    public void Retry()
    {

    }
}
