using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Prototype02
{
    public abstract class P2GameManager : MonoBehaviour
    {
        public static float tempo;
        public static int beat;
        public static int instrumentsCount;

        [SerializeField] private int level;
        [SerializeField] private int exp;
        public int expThreshold;

        [SerializeField] protected P2Player player;
        [SerializeField] protected P2EnemyManager enemyManager;
        [SerializeField] protected P2InputManager inputManager;
        [SerializeField] protected P2PlayerController playerController;
        [SerializeField] protected P2Sheet sheet;
        [SerializeField] protected P2SheetReader sheetReader;
        [SerializeField] protected P2SongWriter songWriter;
        [SerializeField] protected P2SoundManager soundManager;
        [SerializeField] protected P2UIManager uiManager;


        public void Initialize()
        {
            this.level = 0;
            this.exp = 0;

            this.player.Initialize();
            this.player.actionDie += this.EndGame;

            this.enemyManager.Initialize(this.player);
            this.enemyManager.actionGetExp = IncreaseExp;

            this.inputManager.Initialize(playerController);

            this.playerController.Initialize();

            this.sheet.Initialize();

            this.sheetReader.Initialize(this.sheet, this.playerController, soundManager);

            this.songWriter.Initialize(this.sheet);

            this.soundManager.Initialize();

            this.uiManager.Initialize();
            uiManager.closeFloatingUI = CloseFloatingUI;
        }

        public void StartGame()
        {
            this.player.StartGame();
            this.enemyManager.StartGame();
            this.sheetReader.StartGame();
        }

        public void EndGame()
        {
            this.player.EndGame();
            this.enemyManager.EndGame();
            this.sheetReader.EndGame();

            Debug.Log("Game Over");

            StartCoroutine(RestartGame());
        }

        IEnumerator RestartGame()
        {
            yield return new WaitForSeconds(1.5f);

            Debug.Log("Game Restart");

            this.StartGame();
        }

        protected void IncreaseExp(int _exp)
        {
            this.exp += _exp;

            if (this.exp >= this.expThreshold)
            {
                this.LevelUp();
                this.exp = this.exp - this.expThreshold;
            }
        }

        protected void LevelUp()
        {
            this.level++;
            Time.timeScale = 0;
            // inputManager.OpenFloatingUI();
            uiManager.LevelUp();
        }

        protected void CloseFloatingUI()
        {
            Time.timeScale = 1f;
        }
    }
}
