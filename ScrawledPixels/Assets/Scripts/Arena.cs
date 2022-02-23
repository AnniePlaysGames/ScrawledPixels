using UnityEngine;

namespace ScrawledPixels
{
    public class Arena
    {
        public int EnemyCount => _enemyCount;
        private int _enemyCount;
        public int[] EnemyIdArray { get; }
        public string BackgroundName { get; }

        public Arena(string backgroundName, string enemiesIdKey)
        {
            _enemyCount = enemiesIdKey.Length / Const.ENEMY_ID_LENGTH;
            if (KeyIsCorrect(enemiesIdKey, _enemyCount))
            {
                var idArray = new int[_enemyCount];
                for (int i = 1; i < _enemyCount; i++)
                {
                    idArray[i] = int.Parse(enemiesIdKey.Substring(i * Const.ENEMY_ID_LENGTH, Const.ENEMY_ID_LENGTH ));
                }

                EnemyIdArray = idArray;
                BackgroundName = backgroundName;
            }
        }

        private bool KeyIsCorrect(string key, int count)
        {
            if (key.Length % Const.ENEMY_ID_LENGTH == 0 && count <= Const.MAX_ENEMY_COUNT)
            {
                return true;
            }
            else
            {
                Debug.LogError("Incorrect enemiesId in arena!");
                return false;
            }
        }
    }
}