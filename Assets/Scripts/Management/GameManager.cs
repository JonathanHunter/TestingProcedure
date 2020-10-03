﻿namespace Assets.Scripts.Management
{
    using System.Collections.Generic;
    using System.Linq;
    using UnityEngine;

    public class GameManager : MonoBehaviour
    {
        public GameObject Player;
        public Transform spawn;
        public float playerSpawnDelay;
        public float endDelay;

        private void Start()
        {
            _playerSpawned = false;
            _lastWave = false;
            _enemies = null;
        }

        private void Update()
        {
            if (!_playerSpawned && (playerSpawnDelay -= Time.deltaTime) < 0)
            {
                _playerSpawned = true;
                _player = Instantiate(Player);
                _player.transform.position = spawn.position;
            }

            if (_lastWave)
            {
                if (!_enemies.Any(x => x != null))
                    _end = true;
            }

            if (_end || _player == null)
            {
                if ((endDelay -= Time.deltaTime) < 0)
                    Debug.Log("end");
            }
        }

        public void LastWave(IList<GameObject> enemies)
        {
            _lastWave = true;
            _enemies = enemies;
        }

        private bool _playerSpawned;
        private bool _lastWave;
        private bool _end;
        private GameObject _player;
        private IList<GameObject> _enemies;
    }
}
