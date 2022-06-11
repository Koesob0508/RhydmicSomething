using System;
using System.Collections.Generic;
using System.Linq;

[Serializable]
public class SheetLine
{
    public Define.eLineType lineType;
    public List<Note> notes = new List<Note>();
}