using System;
using System.Collections.Generic;
using System.Linq;

[Serializable]
public class SheetLine
{
    public Define.eLineType lineType;
    public List<Note> notes = new List<Note>();

    public SheetLine(int count, Define.eLineType type)
    {
        lineType = type;
        for (int i = 0; i < count; i++)
        {
            notes.Add(new Note());
        }
    }
}