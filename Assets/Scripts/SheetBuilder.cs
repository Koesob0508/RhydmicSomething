using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheetBuilder : MonoBehaviour
{
    public GameManager gameManager;
    public UIManager uiManager;
    public PlayerController playerController;

    public Sheet Sheet;
    public bool isReading = false;
    public float curTime;
    public int noteIndex;
    public float nextNoteTime;
    private List<Note> currentNotes = new List<Note>();

    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        Sheet = new Sheet(100);
    }

    private void Update()
    {
        ReadSheet();
    }

    public void ShowSheetBuilder(int _stageStep)
    {
        Debug.Log("Show Sheet Builder, Stage : " + _stageStep);
    }

    public void HideSheetBuilder()
    {
        Debug.Log("Hide Sheet Builder");
    }

    private void CompleteBuild()
    {
        this.HideSheetBuilder();
        // PlayerController에게 보내는 함수
        gameManager.CompleteBuild();
    }

    public void ReadStart()
    {
        curTime = 0f;
        noteIndex = 0;
        nextNoteTime = Sheet.startTime;
        isReading = true;
    }

    void ReadSheet()
    {
        if (!isReading) return;

        curTime += Time.deltaTime;

        if (nextNoteTime <= curTime)
        {
            currentNotes = Sheet.GetNotes(noteIndex);

            if (currentNotes.Count == 0)
            {
                isReading = false;
                return;
            }

            currentNotes.ForEach(note => Debug.Log(note.noteType));
            noteIndex += 1;
            nextNoteTime = (Sheet.startTime + Sheet.notePerTime * noteIndex);
        }

    }
}
