using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    // public Player playerPrefab;
    public Player player;
    public Monster monsterPrefab;
    public List<Monster> monsters;
    public GameManager gameManager;
    public PlayerController playerController;

    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        this.monsters = new List<Monster>();
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
        
        // this.player = Instantiate<Player>(playerPrefab);
        // this.playerController.SetCharacter(this.player);
        this.player.gameObject.SetActive(true);
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
        this.player.gameObject.SetActive(false);

        if (monsters.Count > 0)
        {
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
            
            monsters.Add(monster);
        }
    }
}
