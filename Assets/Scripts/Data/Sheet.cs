using System;
using System.Collections.Generic;
using System.Linq;

[Serializable]
public class Sheet
{
    public float startTime;
    public float notePerTime;
    public List<SheetLine> sheetLines;
}
