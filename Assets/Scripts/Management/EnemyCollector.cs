namespace Assets.Scripts.Management
{
    using UnityEngine;

    public class EnemyCollector : MonoBehaviour
    {
        private void Start()
        {
            _gameState = GameState.GameStateInstance == null ? FindObjectOfType<GameState>() : GameState.GameStateInstance;
        }

        private void Update()
        {
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (_gameState != null)
                _gameState.EnemiesCollected++;

            Destroy(collision.gameObject);
        }

        private GameState _gameState;
    }
}
