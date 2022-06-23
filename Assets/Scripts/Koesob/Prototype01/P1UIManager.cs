using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


namespace prototype01
{
    public class P1UIManager : MonoBehaviour
    {
        [SerializeField] public GameObject rewardUI;
        public UnityAction closeFloatingUI;

        public void Initialize()
        {
            this.rewardUI.SetActive(false);
        }

        public void GameStart()
        {

        }

        public void GameEnd()
        {

        }

        public void LevelUp()
        {
            this.rewardUI.SetActive(true);
        }

        public void CloseRewardUI()
        {
            this.rewardUI.SetActive(false);
            closeFloatingUI();
        }
    }
}

