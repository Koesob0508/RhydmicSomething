using System;
using System.Collections.Generic;
using System.Linq;

[Serializable]
public class Sheet
{
    public float startTime;
    public float notePerTime;
    public List<SheetLine> sheetLines = new List<SheetLine>();
    private List<Note> returnNotes = new List<Note>();

    public Sheet(int count)
    {
        sheetLines.Add(new SheetLine(count, Define.eLineType.Attack));
        sheetLines.Add(new SheetLine(count, Define.eLineType.Dash));
        sheetLines.Add(new SheetLine(count, Define.eLineType.Heal));
    }

    public List<Note> GetNotes(int index)
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
}
