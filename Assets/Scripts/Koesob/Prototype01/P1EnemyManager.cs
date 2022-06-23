using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace prototype01
{
    public class P1EnemyManager : MonoBehaviour
    {
        public GameObject enemyPrefab;

        public UnityAction<int> actionExp;

        private P1Player player;
        private Coroutine spawnCoroutine;

        public List<GameObject> activeEnemies;
        public List<GameObject> inactiveEnemies;

        public void Initialize(P1Player _player)
        {
            this.player = _player;
            activeEnemies = new List<GameObject>();
            inactiveEnemies = new List<GameObject>();
        }

        public void GameStart()
        {
            spawnCoroutine = StartCoroutine(SpawnEnemy());
        }

        public void GameEnd()
        {
            StopCoroutine(spawnCoroutine);
            foreach (GameObject enemy in activeEnemies)
            {
                enemy.SetActive(false);
                inactiveEnemies.Add(enemy);
            }
            activeEnemies.Clear();
        }

        private void ManageDiedEnemy(bool _isKilled, GameObject _enemyGameObject)
        {
            if(_isKilled)
            {
                actionExp(1);
            }

            activeEnemies.Remove(_enemyGameObject);
            inactiveEnemies.Add(_enemyGameObject);
        }

        private IEnumerator SpawnEnemy()
        {
            while(activeEnemies.Count < 20)
            {
                Vector3 randomPosition = new Vector3(Random.Range(-9f, 9f), 0.7f, Random.Range(-9f, 9f));

                if(inactiveEnemies.Count==0)
                {
                    GameObject enemy = Instantiate(enemyPrefab, randomPosition, Quaternion.identity, this.transform);
                    enemy.GetComponent<P1Enemy>().Initialize();
                    enemy.GetComponent<P1Enemy>().actionInactive = ManageDiedEnemy;
                    enemy.GetComponent<P1Enemy>().GameStart();
                    enemy.GetComponent<P1EnemyController>().Initialize(player);

                    activeEnemies.Add(enemy);
                }
                else
                {
                    GameObject enemy = inactiveEnemies[0];
                    enemy.GetComponent<P1Enemy>().GameStart();
                    enemy.transform.position = randomPosition;
                    inactiveEnemies.Remove(enemy);
                    activeEnemies.Add(enemy);
                }
                

                yield return new WaitForSeconds(2f);
            }
            
        }
    }
}


