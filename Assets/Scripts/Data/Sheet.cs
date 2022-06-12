using System;
using System.Collections.Generic;
using System.Linq;

[Serializable]
public class Sheet
{
    public int totalNoteNum;
    public int noteLength;
    public float startTime;
    public float notePerTime;
    public List<SheetLine> sheetLines = new List<SheetLine>();
    private List<Note> returnNotes = new List<Note>();

    public Sheet(int count, int totalNoteNum = 20)
    {
        this.totalNoteNum = totalNoteNum;
        this.noteLength = count;
        sheetLines.Add(new SheetLine(count, Define.eLineType.Attack));
        sheetLines.Add(new SheetLine(count, Define.eLineType.Dash));
        sheetLines.Add(new SheetLine(count, Define.eLineType.Heal));
        startTime = 2f;
        notePerTime = 0.3333f;
    }

    public List<Note> GetCurrentLineNote(int index)
    {
        returnNotes.Clear();
        for (int i = 0; i < sheetLines.Count; i++)
        {
            if (index < sheetLines[i].notes.Count)
            {
                returnNotes.Add(sheetLines[i].notes[index]);
            }
        }
        return returnNotes;
    }

    private Note GetNote(int _lineIndex, int _noteIndex)
    {
        if (_lineIndex < sheetLines.Count)
        {
            if (_noteIndex < noteLength)
            {
                return sheetLines[_lineIndex].notes[_noteIndex];
            }    
        }

        UnityEngine.Debug.Log($"Error Index {_lineIndex},{_noteIndex}");
        return null;
    }

    public Define.eNoteType GetNoteType(int _lineIndex, int _noteIndex)
    {
        return GetNote(_lineIndex, _noteIndex).noteType;
    }

    public bool UseNote(int _lineIndex, int _noteIndex)
    {
        if (totalNoteNum > 0)
        {
            GetNote(_lineIndex, _noteIndex).noteType = Define.eNoteType.On;
            totalNoteNum -= 1;
            return true;
        }
        else
            return false;
    }

    public bool ReturnNote(int _lineIndex, int _noteIndex)
    {
        Note note = GetNote(_lineIndex, _noteIndex);
        if (note.noteType == Define.eNoteType.On)
        {
            note.noteType = Define.eNoteType.Off;
            totalNoteNum += 1;
            return true;
        }
        else
            return false;
    }
}
