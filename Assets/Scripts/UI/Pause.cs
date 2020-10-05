namespace Assets.Scripts.UI
{
    using Assets.Scripts.Management;
    using UnityEngine;

    public class Pause : MonoBehaviour
    {
        public GameObject menu;

        private void Start()
        {
            _gameState = GameState.GameStateInstance == null ? FindObjectOfType<GameState>() : GameState.GameStateInstance;
        }

        private void Update()
        {
            if (_gameState.CurrentState == GameState.State.Playing)
            {
                if (Input.GetKey(KeyCode.Escape))
                {
                    _gameState.CurrentState = GameState.State.Paused;
                    Physics2D.simulationMode = SimulationMode2D.Script;
                    menu.SetActive(true);
                }
            }
        }

        public void Resume()
        {
            _gameState.CurrentState = GameState.State.Playing;
            Physics2D.simulationMode = SimulationMode2D.FixedUpdate;
            menu.SetActive(false);
        }

        public void Exit()
        {
            Application.Quit();
        }

        private GameState _gameState;
    }
}
