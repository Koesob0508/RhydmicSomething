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
            if (i % ((int)lineType + 1) == 0)
            {
                notes.Add(new Note(Define.eNoteType.On, lineType));
                UnityEngine.Debug.Log("On + " + lineType + " " + i);
            }
            else
            {
                notes.Add(new Note(Define.eNoteType.Off, lineType));
                //UnityEngine.Debug.Log("Off + " + lineType + " " + i + ", " + (i % ((int)lineType) + 1));
            }
        }
    }
}