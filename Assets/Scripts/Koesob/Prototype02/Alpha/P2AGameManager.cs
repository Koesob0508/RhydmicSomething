using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Prototype02
{
    public class P2AGameManager : P2GameManager
    {
        public float currentTempo;

        private void Start()
        {
            tempo = currentTempo;

            this.Initialize();
            this.StartGame();
        }
    }
}

