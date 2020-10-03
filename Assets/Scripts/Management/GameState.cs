namespace Assets.Scripts.Management
{
    using UnityEngine;

    public class GameState : MonoBehaviour
    {
        public enum State { Playing, Paused }

        public State CurrentState;

        public int EnemiesCollected;

        public int Level;

        public int Waves;

        private void Awake()
        {
            CurrentState = State.Playing;
            EnemiesCollected = 0;
            DontDestroyOnLoad(this.gameObject);
        }
    }
}
