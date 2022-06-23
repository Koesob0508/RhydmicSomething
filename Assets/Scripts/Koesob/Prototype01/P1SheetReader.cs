using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace prototype01
{
    public class P1SheetReader : MonoBehaviour
    {
        [SerializeField] private P1Sheet sheet;
        [SerializeField] private P1PlayerController playerController;
        [SerializeField] private P1SoundManager soundManager;
        private Coroutine readCoroutine;
        [SerializeField] private int timing;
        [SerializeField] private Bar currentBar;
        public void Initialize(P1Sheet _sheet, P1PlayerController _playerController, P1SoundManager _soundManager)
        {
            this.sheet = _sheet;
            this.playerController = _playerController;
            this.soundManager = _soundManager;

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

                foreach(int noteNumber in currentBar.notes)
                {
                    this.playerController.Action(noteNumber);
                    this.soundManager.Play(noteNumber);
                }

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

