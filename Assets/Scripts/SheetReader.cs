using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheetReader : MonoBehaviour
{
    public PlayerController PlayerController;

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
            currentNotes = Sheet.GetCurrentLineNote(noteIndex);

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
