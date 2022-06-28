using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Prototype02
{
    [System.Serializable]
    public struct P2Bar
    {
        public List<int> notes;
    }

    public abstract class P2Sheet : MonoBehaviour
    {
        [SerializeField] protected List<P2Bar> sheet;
        public void Initialize()
        {
            sheet = new List<P2Bar>();

            for (int index = 0; index < 3; index++)
            {
                P2Bar nextTrack = new P2Bar();
                nextTrack.notes = new List<int>();
                nextTrack.notes.Add(0);
                sheet.Add(nextTrack);
            }

            P2Bar initTrack = new P2Bar();
            initTrack.notes = new List<int>();
            initTrack.notes.Add(1);
            sheet.Add(initTrack);
        }

        public P2Bar GetSheet(int _time)
        {
            return this.sheet[_time];
        }

        public int GetSheetLength()
        {
            return sheet.Count;
        }

        public void AddNote(int _noteNumber)
        {
            P2Bar additionalTrack = new P2Bar();
            additionalTrack.notes = new List<int>();
            additionalTrack.notes.Add(_noteNumber);
            this.sheet.Add(additionalTrack);

            Debug.Log(this.GenerateLog());
        }

        protected string GenerateLog()
        {
            string resultString = "";
            int timing = 0;

            foreach (P2Bar bars in this.sheet)
            {
                resultString += timing + " timing : ";
                timing++;
                foreach (int note in bars.notes)
                {
                    resultString += note + " n/";
                }
                resultString += " | ";
            }
            return resultString;
        }
    }
}

