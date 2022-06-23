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

        [SerializeField] private P1Sheet sheet;
        [SerializeField] private P1SheetReader sheetReader;
        
        private P1UIManager uiManager;
        
        private P1PlayerController playerController;
        

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
            sheetReader.Initialize(sheet, playerController);
        }

        private void GameStart()
        {
            enemyManager.GameStart();
            player.GameStart();
            sheetReader.GameStart();
        }

        private void GameOver()
        {
            enemyManager.GameEnd();
            sheetReader.GameEnd();
            
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
            Debug.Log("·¹º§ ¾÷");
        }
    }
}


