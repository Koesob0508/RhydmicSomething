using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Prototype02
{
    [System.Serializable]
    public struct P2Bar
    {
        public List<bool> notes;
        public List<int> noteIndices;

        public P2Bar(List<bool> _notes)
        {
            this.notes = _notes;

            this.noteIndices = new List<int>();

            // note에 맞춰서 noteIndices 변경
            int index = 0;
            foreach(bool note in _notes)
            {
                if(note)
                {
                    this.noteIndices.Add(index);
                }

                index++;
            }
        }

        public static P2Bar operator +(P2Bar _p2Bar0, P2Bar _p2Bar1)
        {
            List<bool> resultNotes = new List<bool>();

            (_p2Bar0, _p2Bar1) = _p2Bar0.Padding(_p2Bar0, _p2Bar1);

            for(int index=0; index < _p2Bar0.notes.Count; index++)
            {
                if(_p2Bar0.notes[index] || _p2Bar1.notes[index])
                {
                    resultNotes.Add(true);
                }
                else
                {
                    resultNotes.Add(false);
                }
            }

            P2Bar result = new P2Bar(resultNotes);

            return result;
        }

        public string GetString()
        {
            string result = "";

            int index = 0;

            foreach(bool note in this.notes)
            {
                if(note)
                {
                    result += index + " Play - ";
                }
                else
                {
                    result += index + " Skip - ";
                }

                index++;
            }

            return result;
        }

        private (P2Bar, P2Bar) Padding(P2Bar _p2Bar0, P2Bar _p2Bar1)
        {
            if(_p2Bar0.notes.Count == _p2Bar1.notes.Count)
            {
                return (_p2Bar0, _p2Bar1);
            }
            else if(_p2Bar0.notes.Count > _p2Bar1.notes.Count)
            {
                List<bool> paddingList = _p2Bar1.notes;
                
                while(paddingList.Count < _p2Bar0.notes.Count)
                {
                    paddingList.Add(false);
                }

                _p2Bar1 = new P2Bar(paddingList);

                return (_p2Bar0, _p2Bar1);
            }
            else // _p2Bar1의 사이즈가 더 클 때
            {
                List<bool> paddingList = _p2Bar0.notes;

                while (paddingList.Count < _p2Bar1.notes.Count)
                {
                    paddingList.Add(false);
                }

                _p2Bar0 = new P2Bar(paddingList);

                return (_p2Bar0, _p2Bar1);
            }
        }
    }

    public abstract class P2Sheet : MonoBehaviour
    {
        [SerializeField] protected List<P2Bar> sheet;
        public void Initialize()
        {
            sheet = new List<P2Bar>();
        }

        public List<int> GetSheet(int _time)
        {
            return this.sheet[_time].noteIndices;
        }

        public int GetSheetLength()
        {
            return sheet.Count;
        }

        public void AddBar(P2Bar _bar)
        {
            this.sheet.Add(_bar);

            // Debug.Log(this.GenerateLog());
        }

        protected string GenerateLog()
        {
            string resultString = "";
            int timing = 0;

            foreach (P2Bar bars in this.sheet)
            {
                resultString += timing + " timing : ";
                timing++;
                resultString += bars.GetString();
                resultString += " | ";
            }
            return resultString;
        }
    }
}

