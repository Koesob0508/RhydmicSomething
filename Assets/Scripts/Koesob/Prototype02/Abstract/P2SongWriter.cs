using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Prototype02
{
    public abstract class P2SongWriter : MonoBehaviour
    {
        protected P2Sheet sheet;
        private UnityAction selection;

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
            this.sheet.AddBar(new P2Bar(GetBoolList(-1)));
            this.sheet.AddBar(new P2Bar(GetBoolList(-1)));
            this.sheet.AddBar(new P2Bar(GetBoolList(-1)));
            this.sheet.AddBar(new P2Bar(GetBoolList(-1)));
            this.sheet.AddBar(new P2Bar(GetBoolList(0)));
        }

        public (int, UnityAction, List<int>, string) GetRandomSelectionInfo()
        {
            int index = Random.Range(0, 4);
            List<int> resultList = new List<int>();
            string resultString = "";

            switch (index)
            {
                case 0:
                    this.selection = RewardAttack;
                    resultList = new List<int>() { 1, 2, 0, 0, 0, 0, 0, 0 };
                    resultString = "Add Attack";
                    break;
                case 1:
                    this.selection = RewardDash;
                    resultList = new List<int>() { 1, 1, 2, 0, 0, 0, 0, 0 };
                    resultString = "Add Dash";
                    break;
                case 2:
                    this.selection = RewardEnhancedAttack;
                    resultList = new List<int>() { 1, 1, 1, 2, 0, 0, 0, 0 };
                    resultString = "Add Enhanced Attack";
                    break;
                case 3:
                    this.selection = RewardWaterFall;
                    resultList = new List<int>() { 1, 1, 1, 1, 2, 0, 0, 0 };
                    resultString = "Add Water Attack";
                    break;
                default:
                    break;
            }

            return (index, this.selection, resultList, resultString);
        }

        public void RewardSkip()
        {
            this.sheet.AddBar(new P2Bar(GetBoolList(-1)));
            this.sheet.AddBar(new P2Bar(GetBoolList(-1)));
            this.sheet.AddBar(new P2Bar(GetBoolList(-1)));
            this.sheet.AddBar(new P2Bar(GetBoolList(0)));
        }

        public void RewardAttack()
        {
            this.sheet.AddBar(new P2Bar(GetBoolList(-1)));
            this.sheet.AddBar(new P2Bar(GetBoolList(0)));
        }

        public void RewardDash()
        {
            this.sheet.AddBar(new P2Bar(GetBoolList(-1)));
            this.sheet.AddBar(new P2Bar(GetBoolList(-1)));
            this.sheet.AddBar(new P2Bar(GetBoolList(1)));
        }

        public void RewardEnhancedAttack()
        {
            this.sheet.AddBar(new P2Bar(GetBoolList(-1)));
            this.sheet.AddBar(new P2Bar(GetBoolList(-1)));
            this.sheet.AddBar(new P2Bar(GetBoolList(-1)));
            this.sheet.AddBar(new P2Bar(GetBoolList(0)) + new P2Bar(GetBoolList(2)));
        }

        public void RewardWaterFall()
        {
            this.sheet.AddBar(new P2Bar(GetBoolList(-1)));
            this.sheet.AddBar(new P2Bar(GetBoolList(-1)));
            this.sheet.AddBar(new P2Bar(GetBoolList(-1)));
            this.sheet.AddBar(new P2Bar(GetBoolList(-1)));
            this.sheet.AddBar(new P2Bar(GetBoolList(3)));
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

