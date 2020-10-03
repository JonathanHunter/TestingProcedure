namespace Assets.Scripts.Management
{
    using System.Collections.Generic;
    using Unity.Mathematics;
    using UnityEngine;
    using Random = UnityEngine.Random;

    public class EnemySpawner : MonoBehaviour
    {
        public float initialDelay;
        public float waveDelay;

        public Transform topRight;
        public Transform bottomLeft;
        public GameObject[] enemies;

        private void Start()
        {
            GameState gameState = FindObjectOfType<GameState>();
            if (gameState != null)
            {
                _level = gameState.Level;
                _waves = gameState.Waves;
            }
            else
            {
                _level = 1;
                _waves = 1;
            }

            _curWave = 1;
            _waveTimer = 0;
        }

        private void Update()
        {
            if (_curWave < _waves)
            {
                initialDelay -= Time.deltaTime;
                if (initialDelay <= 0)
                {
                    if (_waveTimer <= 0)
                    {
                        _waveTimer = waveDelay;
                        IList<GameObject> spawns = SpawnWave();
                        _curWave++;

                        if (_curWave == _waves)
                        {

                        }
                    }
                }
            }
        }

        private IList<GameObject> SpawnWave()
        {
            int count = Random.Range(1, _level) * 10 * _level;
            List<GameObject> spawns = new List<GameObject>(count);
            for (int i = 0; i < count; i++)
            {
                int type = Random.Range(0, math.min(_level, (enemies.Length - 1)));
                spawns.Add(Spawn(enemies[type]));
            }

            return spawns;
        }

        private GameObject Spawn(GameObject prefab)
        {
            GameObject g = Instantiate(prefab);
            float x = Random.Range(topRight.position.x, bottomLeft.position.x);
            float y = Random.Range(topRight.position.y, bottomLeft.position.y);
            g.transform.position = new Vector2(x, y);

            return g;
        }

        private int _level;
        private int _waves;
        private int _curWave;
        private float _waveTimer;
    }
}
