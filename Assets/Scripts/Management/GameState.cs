namespace Assets.Scripts.Management
{
    using UnityEngine;

    public class GameState : MonoBehaviour
    {
        public enum State { Playing, Paused }

        public State CurrentState;

        private void Awake()
        {
            CurrentState = State.Playing;
        }
    }
}
