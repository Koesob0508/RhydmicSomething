using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace prototype01
{
    public class P1SheetReader : MonoBehaviour
    {
        [SerializeField] private P1Sheet sheet;
        [SerializeField] private P1PlayerController playerController;
        private Coroutine readCoroutine;
        [SerializeField] private int timing;
        [SerializeField] private Bar currentBar;
        public void Initialize(P1Sheet _sheet, P1PlayerController _playerController)
        {
            this.sheet = _sheet;
            playerController = _playerController;

            this.timing = 0;
        }

        public void GameStart()
        {
            this.timing = 0;
            readCoroutine = StartCoroutine(ReadSheet());
        }

        public void GameEnd()
        {
            StopCoroutine(readCoroutine);
        }

        private IEnumerator ReadSheet()
        {
            while(true)
            {
                this.currentBar = this.sheet.GetSheet(timing);

                foreach(int actionNumber in currentBar.notes)
                {
                    this.playerController.Action(actionNumber);
                }

                Debug.Log("Read");
                yield return new WaitForSeconds(.5f);

                if(timing == sheet.GetSheetLength()-1)
                {
                    timing = 0;
                }
                else
                {
                    timing++;
                }
            }
        }
    }

}

