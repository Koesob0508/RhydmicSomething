using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Define
{
    public enum eNoteType
    {
        none = 0,
        On = 1,
        Off = 2,
    }


    public enum eLineType
    {
        none = 0,
        Attack = 1,
        Dash= 2,
        Heal = 3,
    }

    public enum eStageStatus
    {
        none = 0,
        Init,
        Start,
        Succeed,
        Fail,
    }

}