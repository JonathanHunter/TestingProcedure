namespace Assets.Scripts.UI
{
    using UnityEngine;
    using UnityEngine.UI;

    public class WaveNotification : MonoBehaviour
    {
        public RectTransform textPosition;
        public RectTransform onscreen;
        public RectTransform offscreen;
        public float speed;
        public float textTime;

        public Text text;

        private void Start()
        {
            textPosition.position = offscreen.position;
            text.text = "";
        }

        private void Update()
        {
            if (_entering)
            {
                _lerp += Time.deltaTime * speed * 1.5f;
                textPosition.position = Vector3.Lerp(offscreen.position, onscreen.position, _lerp);

                if (_lerp >= 1)
                {
                    _entering = false;
                    _waiting = true;
                    _leaving = false;
                    _timer = textTime;
                }                    
            }

            if (_waiting)
            {
                if ((_timer -= Time.deltaTime) <= 0)
                {
                    _waiting = false;
                    _leaving = true;
                }
            }

            if (_leaving)
            {
                _lerp -= Time.deltaTime * speed;
                textPosition.position = Vector3.Lerp(offscreen.position, onscreen.position, _lerp);

                if (_lerp <= 0)
                    _leaving = false;
            }
        }

        public void Notify(int wave)
        {
            text.text = $"Spawning wave: {wave}";
            textPosition.position = offscreen.position;
            _entering = true;
            _leaving = false;
            _lerp = 0;
        }

        private bool _entering;
        private bool _waiting;
        private bool _leaving;
        private float _lerp;
        private float _timer;
    }
}
