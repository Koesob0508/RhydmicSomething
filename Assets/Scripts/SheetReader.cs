using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheetReader : MonoBehaviour
{
    public PlayerController PlayerController;

    public AudioSource bgm;
    public AudioSource atk;
    public AudioSource dash;
    public AudioSource heal;

    public Sheet Sheet;
    public bool isReading = false;
    public float curTime;
    public int noteIndex;
    public float nextNoteTime;
    private List<Note> currentNotes = new List<Note>();

    private bool isSet = false;

    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        Sheet = new Sheet(100);

        GameManager.instance.stageManager.stageAction += StageChanged;
    }

    private void Update()
    {
        ReadSheet();
    }

    void StageChanged(Define.eStageStatus status)
    {
        switch (status)
        {
            case Define.eStageStatus.Init:
                StartRead();
                break;
            case Define.eStageStatus.Succeed:
            case Define.eStageStatus.Fail:
                EndRead();
                break;
        }
    }

    void StartRead()
    {
        curTime = 0f;
        noteIndex = 0;
        nextNoteTime = Sheet.startTime;
        isReading = true;

        bgm.Play();
    }

    void EndRead()
    {
        curTime = 0f;
        noteIndex = 0;
        nextNoteTime = Sheet.startTime;
        isReading = false;

        bgm.Stop();
    }

    void ReadSheet()
    {
        if (!isReading) return;
        Debug.Log("Reading");
        curTime += Time.deltaTime;

        if (nextNoteTime <= curTime)
        {
            currentNotes = Sheet.GetCurrentLineNote(noteIndex);

            if (currentNotes.Count == 0)
            {
                isReading = false;
                return;
            }

            currentNotes.ForEach(note =>
            {
                if (note.noteType == Define.eNoteType.On)
                {
                    switch (note.lineType)
                    {
                        case Define.eLineType.Attack:
                            PlayerController.Attack();
                            atk.Play();
                            break;
                        case Define.eLineType.Dash:
                            PlayerController.Dash();
                            dash.Play();
                            break;
                        case Define.eLineType.Heal:
                            PlayerController.Heal();
                            heal.Play();
                            break;
                    }
                }
            });

            noteIndex += 1;
            nextNoteTime = (Sheet.startTime + Sheet.notePerTime * noteIndex);
        }

    }
}
