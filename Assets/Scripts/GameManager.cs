using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public UIManager uiManager;
    public StageManager stageManager;

    public int stageStep;

    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public void CompleteBuild()
    {
        Debug.Log("GameManager received complete sheet build");
        // SceneManager.LoadScene("StageScene"); 확인 동안 MainScene에서만 작업합니다.
        this.stageManager.GenerateStage(stageStep);
    }

    public void Failed()
    {
        Debug.Log("Stage Failed");
        // SceneManager.LoadScene("MainScene");
        uiManager.StageFail();
    }

    public void Succeeded()
    {
        Debug.Log("Stage Succeeded");
        stageStep++;
        // SceneManager.LoadScene("MainScene");
        uiManager.StageClear(stageStep);
    }
}
