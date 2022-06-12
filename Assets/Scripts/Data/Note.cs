using System;
using System.Collections.Generic;
using System.Linq;

[Serializable]
public class Note
{
    public Define.eNoteType noteType;

    public Note()
    {
        noteType = Define.eNoteType.none;
    }

    public Note(Define.eNoteType type)
    {
        noteType = type;
    }
}