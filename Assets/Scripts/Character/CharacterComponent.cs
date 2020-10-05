namespace Assets.Scripts.Character
{
    using UnityEngine;
    using Management;

    public abstract class CharacterComponent : MonoBehaviour
    {
        private void Start()
        {
            Init();
            _gameState = GameState.GameStateInstance == null ? FindObjectOfType<GameState>() : GameState.GameStateInstance;
        }

        private void Update()
        {
            if (_gameState?.CurrentState == GameState.State.Playing)
                Run();
        }

        protected abstract void Init();
        protected abstract void Run();

        private GameState _gameState;
    }
}
