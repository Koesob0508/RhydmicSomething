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
            Bar initTrack = new Bar();
            initTrack.notes = new List<int>();
            initTrack.notes.Add(1);
            sheet.Add(initTrack);
            for(int index = 0; index < 3; index++)
            {
                Bar nextTrack = new Bar();
                nextTrack.notes = new List<int>();
                nextTrack.notes.Add(0);
                sheet.Add(nextTrack);
            }
        }

        public Bar GetSheet(int _time)
        {
            return this.sheet[_time];
        }

        public int GetSheetLength()
        {
            return sheet.Count;
        }
    }
}


