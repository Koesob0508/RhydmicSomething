using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Prototype02
{
    public abstract class P2UIManager : MonoBehaviour
    {
        [SerializeField] protected GameObject pannel;
        [SerializeField] protected GameObject rewardUI;


        public UnityAction closeFloatingUI;

        public void Initialize()
        {
            this.rewardUI.SetActive(false);
            InactivatePannel();
        }

        public void LevelUp()
        {
            this.ActivatePannel();
            this.rewardUI.SetActive(true);
        }

        public void CloseRewardUI()
        {
            this.rewardUI.SetActive(false);
            closeFloatingUI();
            this.InactivatePannel();
        }
        protected void ActivatePannel()
        {
            this.pannel.SetActive(true);
        }
        protected void InactivatePannel()
        {
            this.pannel.SetActive(false);
        }
        
    }
}

