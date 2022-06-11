using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public UIManager uiManager;
    public StageManager stageManager;
    public SheetBuilder sheetBuilder;

    public int stageStep;

    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        this.sheetBuilder.ShowSheetBuilder(stageStep);
    }

    public void CompleteBuild()
    {
        Debug.Log("GameManager received complete sheet build");
        SceneManager.LoadScene("StageScene");
        this.stageManager.GenerateStage(stageStep);
    }

    public void Failed()
    {
        Debug.Log("Stage Failed");
        SceneManager.LoadScene("MainScene");
        uiManager.ShowUI();
    }

    public void Succeeded()
    {
        Debug.Log("Stage Succeeded");
        stageStep++;
        SceneManager.LoadScene("MainScene");
        this.sheetBuilder.ShowSheetBuilder(stageStep);
    }
}
