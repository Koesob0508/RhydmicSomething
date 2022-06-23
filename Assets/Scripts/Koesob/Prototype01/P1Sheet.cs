using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace prototype01
{
    [System.Serializable]
    public struct Bar
    {
        public List<int> notes;
    }

    public class P1Sheet : MonoBehaviour
    {
        [SerializeField] private List<Bar> sheet;

        public void Initialize()
        {
            Debug.Log("Sheet Initialize");
            sheet = new List<Bar>();
            
            for(int index = 0; index < 3; index++)
            {
                Bar nextTrack = new Bar();
                nextTrack.notes = new List<int>();
                nextTrack.notes.Add(0);
                sheet.Add(nextTrack);
            }

            Bar initTrack = new Bar();
            initTrack.notes = new List<int>();
            initTrack.notes.Add(1);
            sheet.Add(initTrack);
        }

        public Bar GetSheet(int _time)
        {
            return this.sheet[_time];
        }

        public int GetSheetLength()
        {
            return sheet.Count;
        }

        public void AddNote(int _noteNumber)
        {
            Bar additionalTrack = new Bar();
            additionalTrack.notes = new List<int>();
            additionalTrack.notes.Add(_noteNumber);
            this.sheet.Add(additionalTrack);

            Debug.Log(this.GenerateLog());
        }

        private string GenerateLog()
        {
            string resultString = "";
            int timing = 0;

            foreach(Bar bars in this.sheet)
            {
                resultString += timing + " timing : ";
                timing++;
                foreach(int note in bars.notes)
                {
                    resultString += note + " n/";
                }
                resultString += " | ";
            }
            return resultString;
        }
    }
}


