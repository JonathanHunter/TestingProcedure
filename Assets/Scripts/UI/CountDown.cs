namespace Assets.Scripts.UI
{
    using UnityEngine;
    using UnityEngine.UI;

    public class CountDown : MonoBehaviour
    {
        public Text text;

        private void Update()
        {
            if (_countingDown)
            {
                text.enabled = true;
                text.text = $"{(int)_time + 1}";
                _time -= Time.deltaTime;
                if (_time < .2)
                {
                    _countingDown = false;
                    text.enabled = false;
                }
            }
        }

        public void Countdown(int from)
        {
            _countingDown = true;
            _time = from;
        }

        private float _time;
        private bool _countingDown;
    }
}
