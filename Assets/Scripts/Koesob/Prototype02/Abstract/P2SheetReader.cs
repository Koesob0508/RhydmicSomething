using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Prototype02
{
    public abstract class P2SheetReader : MonoBehaviour
    {
        protected P2Sheet sheet;
        protected P2PlayerController playerController;
        protected P2SoundManager soundManager;
        protected Coroutine readCoroutine;
        protected int timing;
        [SerializeField] protected List<int> currentNotes;

        public bool isSheet;
        public bool isPlayerController;
        public bool isSoundManager;
        public bool isTimingZero;
        
        public void Initialize(P2Sheet _sheet, P2PlayerController _playerController, P2SoundManager _soundManager)
        {
            this.sheet = _sheet;
            this.playerController = _playerController;
            this.soundManager = _soundManager;

            this.timing = 0;

            if(this.sheet.gameObject)
            {
                this.isSheet = true;
            }

            if(this.playerController.gameObject)
            {
                this.isPlayerController = true;
            }

            if(this.soundManager.gameObject)
            {
                this.isSoundManager = true;
            }

            if(this.timing == 0)
            {
                isTimingZero = true;
            }
        }

        public void StartGame()
        {
            this.timing = 0;
            readCoroutine = StartCoroutine(ReadSheet());
        }

        public void EndGame()
        {
            StopCoroutine(readCoroutine);
        }

        protected IEnumerator ReadSheet()
        {
            while (true)
            {
                this.currentNotes = this.sheet.GetSheet(timing);

                foreach (int noteIndex in currentNotes)
                {
                    this.playerController.Action(noteIndex);
                    this.soundManager.Play(noteIndex);
                }

                yield return new WaitForSeconds(P2GameManager.tempo);

                if (timing == sheet.GetSheetLength() - 1)
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

