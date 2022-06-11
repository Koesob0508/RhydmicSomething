using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public Player playerPrefab;
    public Player player;
    public Monster monsterPrefab;
    public List<Monster> monsters;
    public List<MonsterController> monsterControllers;
    public GameManager gameManager;
    public PlayerController playerController;

    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        this.monsters = new List<Monster>();
        this.monsterControllers = new List<MonsterController>();
    }

    // void Update()
    // {
    //     if (this.gameObject.activeSelf && !player.gameObject.activeSelf)
    //     {
    //         this.StageFailed();
    //     }

    //     if (this.gameObject.activeSelf && monsters.Count == 0)
    //     {
    //         this.StageSucceeded();
    //     }
    // }

    public void GenerateStage(int _stageStep)
    {
        Debug.Log(_stageStep + "단계 Stage 생성");

        this.monsters.Clear();
        this.monsterControllers.Clear();
        
        this.player = Instantiate<Player>(playerPrefab);
        this.playerController.SetPawn(this.player);
        this.SpanwMonster(_stageStep);
    }

    private void StageFailed()
    {
        this.StageClear();
        this.gameManager.Failed();
        
    }

    private void StageSucceeded()
    {
        this.StageClear();
        this.gameManager.Succeeded();
    }

    private void StageClear()
    {
        if (this.player.gameObject)
        {
            Destroy(this.player);
        }

        if (monsters.Count > 0)
        {
            foreach(MonsterController monsterController in monsterControllers)
            {
                Destroy(monsterController.gameObject);
            }
            foreach (Monster monster in monsters)
            {
                Destroy(monster.gameObject);
            }
        }
    }

    private void SpanwMonster(int _spawnCount)
    {
        for (int count = 0; count < _spawnCount; count++)
        {
            Monster monster = Instantiate<Monster>(monsterPrefab);

            // 이거 바꿔야하는데 어떻게 바꿀까...
            MonsterController monsterController = new MonsterController();
            monsterController.SetPawn(monster);
            
            monsters.Add(monster);
            monsterControllers.Add(monsterController);
        }
    }
}
