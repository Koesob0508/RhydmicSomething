using System;
using System.Collections.Generic;
using System.Linq;

[Serializable]
public class Note
{
    public Define.eNoteType noteType;
    public Define.eLineType lineType;

    public Note()
    {
        noteType = Define.eNoteType.Off;
    }

    public Note(Define.eNoteType noteType, Define.eLineType lineType)
    {
        this.noteType = noteType;
        this.lineType = lineType;
    }
}