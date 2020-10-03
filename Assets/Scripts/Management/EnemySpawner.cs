namespace Assets.Scripts.Management
{
    using System.Collections.Generic;
    using System.Linq;
    using TMPro;
    using Unity.Mathematics;
    using UnityEngine;
    using Random = UnityEngine.Random;

    public class EnemySpawner : MonoBehaviour
    {
        public GameManager gameManager;
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

            _curWave = 0;
            _waveTimer = initialDelay;
        }

        private void Update()
        {
            if (_curWave < _waves)
            {
                if ((_waveTimer -= Time.deltaTime) <= 0)
                {
                    Debug.Log("spawned wave");
                    _waveTimer = waveDelay;
                    _spawns = SpawnWave();
                    _curWave++;

                    if (_curWave == _waves)
                        gameManager.LastWave(_spawns);
                }

                if (_spawns != null && !_spawns.Any(x => x != null))
                {
                    Debug.Log("a");
                    _waveTimer = 0;
                }
            }

        }

        private IList<GameObject> SpawnWave()
        {
            int count = Random.Range(1, _level) * _level + 5;
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
        private IList<GameObject> _spawns;
    }
}
