using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Prototype02
{
    public abstract class P2SongWriter : MonoBehaviour
    {
        protected P2Sheet sheet;

        public bool isSheet;

        public void Initialize(P2Sheet _sheet)
        {
            this.sheet = _sheet;

            if(this.sheet)
            {
                isSheet = true;
            }

            this.sheet.AddBar(new P2Bar(GetBoolList(-1)));
            this.sheet.AddBar(new P2Bar(GetBoolList(-1)));
            this.sheet.AddBar(new P2Bar(GetBoolList(-1)));
            this.sheet.AddBar(new P2Bar(GetBoolList(0)));
            this.sheet.AddBar(new P2Bar(GetBoolList(-1)));
            this.sheet.AddBar(new P2Bar(GetBoolList(-1)));
            this.sheet.AddBar(new P2Bar(GetBoolList(-1)));
            this.sheet.AddBar(new P2Bar(GetBoolList(0)));
        }

        public void RewardSkip()
        {
            this.sheet.AddBar(new P2Bar(GetBoolList(-1)));
            this.sheet.AddBar(new P2Bar(GetBoolList(-1)));
            this.sheet.AddBar(new P2Bar(GetBoolList(-1)));
            this.sheet.AddBar(new P2Bar(GetBoolList(0)));
            this.sheet.AddBar(new P2Bar(GetBoolList(-1)));
            this.sheet.AddBar(new P2Bar(GetBoolList(-1)));
            this.sheet.AddBar(new P2Bar(GetBoolList(-1)));
            this.sheet.AddBar(new P2Bar(GetBoolList(0)));
        }

        public void RewardAttack()
        {
            this.sheet.AddBar(new P2Bar(GetBoolList(-1)));
            this.sheet.AddBar(new P2Bar(GetBoolList(0)));
            this.sheet.AddBar(new P2Bar(GetBoolList(-1)));
            this.sheet.AddBar(new P2Bar(GetBoolList(0)));
            this.sheet.AddBar(new P2Bar(GetBoolList(-1)));
            this.sheet.AddBar(new P2Bar(GetBoolList(0)));
            this.sheet.AddBar(new P2Bar(GetBoolList(-1)));
            this.sheet.AddBar(new P2Bar(GetBoolList(0)));
        }

        public void RewardDash()
        {
            this.sheet.AddBar(new P2Bar(GetBoolList(-1)));
            this.sheet.AddBar(new P2Bar(GetBoolList(-1)));
            this.sheet.AddBar(new P2Bar(GetBoolList(1)));
            this.sheet.AddBar(new P2Bar(GetBoolList(0)));
            this.sheet.AddBar(new P2Bar(GetBoolList(-1)));
            this.sheet.AddBar(new P2Bar(GetBoolList(-1)));
            this.sheet.AddBar(new P2Bar(GetBoolList(1)));
            this.sheet.AddBar(new P2Bar(GetBoolList(0)));
        }

        public void RewardEnhancedAttack()
        {
            this.sheet.AddBar(new P2Bar(GetBoolList(-1)));
            this.sheet.AddBar(new P2Bar(GetBoolList(-1)));
            this.sheet.AddBar(new P2Bar(GetBoolList(-1)));
            this.sheet.AddBar(new P2Bar(GetBoolList(0)) + new P2Bar(GetBoolList(2)));
            this.sheet.AddBar(new P2Bar(GetBoolList(-1)));
            this.sheet.AddBar(new P2Bar(GetBoolList(-1)));
            this.sheet.AddBar(new P2Bar(GetBoolList(-1)));
            this.sheet.AddBar(new P2Bar(GetBoolList(0)) + new P2Bar(GetBoolList(2)));
        }

        protected List<bool> GetBoolList(int _index)
        {
            List<bool> result = new List<bool>();

            if(_index == -1)
            {
                int index = 0;
                while(index < P2GameManager.instrumentsCount)
                {
                    result.Add(false);

                    index++;
                }

                return result;
            }
            else
            {
                int index = 0;

                while (index < P2GameManager.instrumentsCount)
                {
                    if (index == _index)
                    {
                        result.Add(true);
                    }
                    else
                    {
                        result.Add(false);
                    }

                    index++;
                }

                return result;
            }
        }
    }
}

