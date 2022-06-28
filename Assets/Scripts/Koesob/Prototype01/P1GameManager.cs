using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace prototype01
{
    public class P1GameManager : MonoBehaviour
    {
        [SerializeField] private int level;
        [SerializeField] private int exp;
        public int expThreshold;
        [SerializeField] private P1Player player;
        [SerializeField] private P1InputManager inputManager;
        [SerializeField] private P1EnemyManager enemyManager;
        private P1PlayerController playerController;

        [SerializeField] private P1Sheet sheet;
        [SerializeField] private P1SheetReader sheetReader;
        [SerializeField] private P1SoundManager soundManager;
        
        [SerializeField] private P1UIManager uiManager;
        
        
        

        // Start is called before the first frame update
        void Start()
        {
            this.level = 0;
            this.exp = 0;

            this.GameInitialize();
            this.GameStart();
        }

        private void GameInitialize()
        {
            player.Initialize();
            player.actionDie += this.GameOver;
            playerController = player.gameObject.GetComponent<P1PlayerController>();

            playerController.Initialize();
            inputManager.Initialize(player);
            enemyManager.Initialize(player);
            enemyManager.actionExp = IncreaseExp;

            sheet.Initialize();
            sheetReader.Initialize(sheet, playerController, soundManager);
            soundManager.Initialize();
            uiManager.Initialize();
            uiManager.closeFloatingUI = CloseFloatingUI;
        }

        private void GameStart()
        {
            enemyManager.GameStart();
            inputManager.GameStart();
            player.GameStart();
            sheetReader.GameStart();
            uiManager.GameStart();
        }

        private void GameOver()
        {
            enemyManager.GameEnd();
            inputManager.GameEnd();
            sheetReader.GameEnd();
            uiManager.GameEnd();
            
            Debug.Log("Game Over");

            StartCoroutine(GameRestart());
        }

        IEnumerator GameRestart()
        {
            yield return new WaitForSeconds(3.0f);

            Debug.Log("Game Restart");
            GameStart();
        }

        public void IncreaseExp(int _exp)
        {
            this.exp += _exp;

            if(this.exp >= this.expThreshold)
            {
                this.LevelUp();
                this.exp = this.exp - this.expThreshold;
            }
        }

        private void LevelUp()
        {
            this.level++;
            Time.timeScale = 0;
            inputManager.OpenFloatingUI();
            uiManager.LevelUp();
        }

        private void CloseFloatingUI()
        {
            Time.timeScale = 1;
            inputManager.CloseFloatingUI();
        }
    }
}


