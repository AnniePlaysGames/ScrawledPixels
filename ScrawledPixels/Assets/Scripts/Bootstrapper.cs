using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using ScrawledPixels;
using ScrawledPixels.BattleLogic;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace DefaultNamespace
{
    public class Bootstrapper : MonoBehaviour
    {
        [SerializeField] private GameObject _enemyPrefab; 
        private EnemyData[] _enemyDataBase;

        private void Awake()
        {
           _enemyDataBase = InitEnemyDatabase();
        }

        private void Start()
        {
            StartBattle(_enemies);
        }

        private EnemyData[] InitEnemyDatabase()
        {
            return Resources.LoadAll<EnemyData>("Enemies");
        }

        private void StartBattle(Dictionary<GameObject,EnemyData> enemies)
        {
            for (int i = 0; i < enemies.Count; i++)
            {
                var enemyFighter = enemies[i].GetComponent<EnemyFighter>();
                enemyFighter.AttachData();
            }
            
           
            Debug.Log("Fight has started");
            Debug.Log($"Enemy's name is {enemyFighter.Name}, " +
                      $"It's parameters {enemyFighter.Health}/{enemyFighter.Damage}");
        }
    }
}