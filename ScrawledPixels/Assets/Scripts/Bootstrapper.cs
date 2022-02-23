using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using ScrawledPixels;
using ScrawledPixels.BattleLogic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.PlayerLoop;

namespace DefaultNamespace
{
    public class Bootstrapper : MonoBehaviour
    {
        [SerializeField] private GameObject _enemyPrefab;
        private Dictionary<int, EnemyData> _enemyDataBase;

        private void Awake()
        {
            _enemyDataBase = InitEnemyDatabase();
        }

        private void Start()
        {
            StartBattle(new Arena("Test", "01"));
        }
        
        private void StartBattle(Arena arena)
        {
            GameObject[] enemies = InitEnemyGameObjects(arena.EnemyCount, arena.EnemyIdArray);
        }

        private Dictionary<int, EnemyData> InitEnemyDatabase()
        {
            EnemyData[] _dataArray = Resources.LoadAll<EnemyData>("Enemies");
            var enemyDataBase = new Dictionary<int,EnemyData>();
            for (int i = 0; i < _dataArray.Length; i++)
            {
                enemyDataBase.Add(_dataArray[i].Id, _dataArray[i]);
            }

            return enemyDataBase;
        }

        private GameObject[] InitEnemyGameObjects(int count, int[] enemiesId)
        {
            var enemies = new GameObject[count];
            for (int i = 0; i < count; i++)
            {
                enemies[i] = Instantiate(_enemyPrefab);
            }

            return enemies;
        }
    }
}