using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


namespace Prototype02
{
    public abstract class P2EnemyManager : MonoBehaviour
    {
        public int enemyThreshold;

        protected P2Player targetPlayer;
        protected Coroutine spawnCoroutine;

        [SerializeField] protected P2Enemy enemyPrefab;

        public UnityAction<int> actionGetExp;

        public bool isTargetPlayer;

        public List<GameObject> activeEnemies;
        public List<GameObject> inactiveEnemies;

        public void Initialize(P2Player _player)
        {
            this.targetPlayer = _player;
            this.activeEnemies = new List<GameObject>();
            this.inactiveEnemies = new List<GameObject>();


            if(targetPlayer.gameObject)
            {
                this.isTargetPlayer = true;
            }
            else
            {
                this.isTargetPlayer = false;
            }
        }

        public void StartGame()
        {
            spawnCoroutine = StartCoroutine(SpawnEnemy());
        }

        public void EndGame()
        {
            StopCoroutine(spawnCoroutine);
            foreach (GameObject enemy in activeEnemies)
            {
                enemy.GetComponent<P2Enemy>().EndGame();
                inactiveEnemies.Add(enemy);
            }
            activeEnemies.Clear();
        }

        protected IEnumerator SpawnEnemy()
        {
            while (activeEnemies.Count < this.enemyThreshold)
            {
                Vector2 randomPosition = new Vector2(Random.Range(-9f, 9f), Random.Range(-9f, 9f));

                if (inactiveEnemies.Count == 0)
                {
                    P2Enemy enemy = Instantiate(enemyPrefab, randomPosition, Quaternion.identity, this.transform);
                    enemy.Initialize();
                    enemy.actionInactive = ManageDiedEnemy;
                    enemy.StartGame();
                    enemy.gameObject.GetComponent<P2EnemyController>().Initialize(this.targetPlayer);

                    activeEnemies.Add(enemy.gameObject);
                }
                else
                {
                    GameObject enemy = inactiveEnemies[0];
                    enemy.GetComponent<P2Enemy>().StartGame();
                    enemy.transform.position = randomPosition;
                    inactiveEnemies.Remove(enemy);
                    activeEnemies.Add(enemy);
                }


                yield return new WaitForSeconds(P2GameManager.tempo * 4);
            }
        }

        protected void ManageDiedEnemy(bool _isKilled, GameObject _enemyGameObject)
        {
            if (_isKilled)
            {
                actionGetExp(1);
            }

            activeEnemies.Remove(_enemyGameObject);
            inactiveEnemies.Add(_enemyGameObject);
        }
    }
}
