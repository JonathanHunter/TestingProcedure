namespace Assets.Scripts.UI
{
    using UnityEngine;
    using UnityEngine.SceneManagement;
    using UnityEngine.UI;

    public class Cutscene : MonoBehaviour
    {
        public float time;
        public string level;
        public bool quit;

        public Text[] texts;

        private void Start()
        {
            _timer = time;
            _text = 0;
        }

        private void Update()
        {
            if (_text < texts.Length)
            {
                if ((_timer += Time.deltaTime) >= time)
                {
                    _timer = 0;
                    texts[_text].gameObject.SetActive(true);
                    if (_text > 0)
                        texts[_text - 1].gameObject.SetActive(false);

                    _text++;
                }
            }
            else
            {
                if (quit)
                    Application.Quit();

                if (Input.GetKey(KeyCode.Return))
                    SceneManager.LoadScene(level);
            }
        }

        private float _timer;
        private int _text;
    }
}
