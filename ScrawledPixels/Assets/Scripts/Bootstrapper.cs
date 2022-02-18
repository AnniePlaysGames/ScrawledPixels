using System;
using System.Collections.Generic;
using ScrawledPixels;
using ScrawledPixels.BattleLogic;
using UnityEngine;

namespace DefaultNamespace
{
    public class Bootstrapper : MonoBehaviour
    {
        [SerializeField] private GameObject _enemyPrefab;
        [SerializeField] private EnemyData _enemyData;
        private GameObject _enemy;
        private EnemyFighter _enemyFighter;

        private void Awake()
        {
           _enemy = RegisterEnemy(_enemyPrefab);
        }

        private void Start()
        {
            StartBattle(_enemy);
        }

        private GameObject RegisterEnemy(GameObject enemyPrefab)
        {
            var enemy = Instantiate(enemyPrefab);
            enemy.SetActive(false);
            return enemy;
        }

        private void StartBattle(GameObject enemy)
        {
            var enemyFighter = enemy.GetComponent<EnemyFighter>();
            enemyFighter.AttachData(_enemyData);
            enemy.SetActive(true);
            Debug.Log("Бой начался!!!");
            Debug.Log($"Врага зовут {enemyFighter.Name}, " +
                      $"Его показатели {enemyFighter.Health}/{enemyFighter.Damage}");
        }
    }
}