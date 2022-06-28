using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Prototype02
{
    public class P2AGameManager : P2GameManager
    {
        public float currentTempo;
        public int currentBeat;
        public int currentInstrumentsCount;

        private void Start()
        {
            tempo = currentTempo;
            beat = currentBeat;
            instrumentsCount = currentInstrumentsCount;

            this.Initialize();
            this.StartGame();
        }
    }
}

