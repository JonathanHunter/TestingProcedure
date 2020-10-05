namespace Assets.Scripts.Management
{
    using UnityEngine;

    public class GameState : MonoBehaviour
    {
        public static GameState GameStateInstance;

        public enum State { Playing, Paused }

        public State CurrentState;

        public int EnemiesCollected;

        public int testsAdded;

        public int Level;

        public int Waves;

        public string testText;

        public int rounds;

        private void Awake()
        {
            if (GameStateInstance == null)
            {
                CurrentState = State.Playing;
                EnemiesCollected = 0;
                Level = 1;
                Waves = 1;
                GameStateInstance = this;
                DontDestroyOnLoad(this.gameObject);
            } 
            else
            {
                Destroy(this.gameObject);
            }
        }
    }
}
