namespace Assets.Scripts.Management
{
    using Unity.Mathematics;
    using UnityEngine;
    using UnityEngine.SceneManagement;
    using UnityEngine.UI;
    using Random = UnityEngine.Random;

    public class LevelManager : MonoBehaviour
    {
        public int testMax;
        public Text testTotal;
        public Text testWindow;
        public GameObject complaintsObject;
        public Text complaints;
        public float complaintTime;

        public GameObject cameraObject;
        public Transform start;
        public Transform end;
        public float speed;

        private void Start()
        {
            _gameState = GameState.GameStateInstance == null ? FindObjectOfType<GameState>() : GameState.GameStateInstance;
            testTotal.text = $"Test Progress: {_gameState.EnemiesCollected}/{testMax}";
            string oldText = _gameState.testText;
            int size = (_gameState.EnemiesCollected / 10) - _gameState.testsAdded;
            if (_gameState.EnemiesCollected / 10 > 14)
                size = 14 - _gameState.testsAdded;

            if (size > 0)
            {
                _newtext = new string[size];
                for (int i = 0; i < size; i++)
                    _newtext[i] = $"Test.{_tests[Random.Range(0, _tests.Length)]} ({Random.Range(1, 100)}s)\n";
            }
            else
                _newtext = null;

            testWindow.text = "Tests:\n" + _gameState.testText;
            complaints.text = _complaints[Random.Range(0, _complaints.Length)];
            _timer = 0;
            _state = 0;
            _temp = 0;
            _gameState.rounds++;
            _gameState.Level = math.max(_gameState.rounds / 2, 1);
            _gameState.Waves = Random.Range(1, 5);
        }

        private void Update()
        {
            if (_state == 0)
            {
                if ((_timer += Time.deltaTime) > 1)
                {
                    testWindow.text += _newtext[_temp];
                    _gameState.testText += _newtext[_temp];
                    _gameState.testsAdded++;
                    _temp++;
                    _timer = 0;
                }

                if (_newtext == null || _temp >= _newtext.Length)
                {
                    _timer = 0;
                    _state++;
                    if (_gameState.EnemiesCollected >= testMax)
                    {
                        testWindow.text += "DONE";
                        complaints.text = "FINALLY DONE!";
                    }
                }
            }

            if (_state == 1)
            {
                complaintsObject.SetActive(true);
                if ((_timer += Time.deltaTime) > complaintTime)
                {
                    _timer = 0;
                    _state++;
                }
            }

            if (_state == 2)
            {
                _timer += Time.deltaTime * speed;
                cameraObject.transform.position = Vector3.Lerp(start.position, end.position, _timer);

                if (_timer > 1)
                {
                    if (_gameState.EnemiesCollected >= testMax)
                        SceneManager.LoadScene("End");
                    else
                        SceneManager.LoadScene("Test");
                }
            }
        }

        private GameState _gameState;
        private string[] _newtext;
        private float _timer;
        private int _state;
        private int _temp;

        private readonly string[] _tests = new string[]
        {
            "SystemA",
            "SystemB",
            "SystemC",
            "SystemD",
            "DumbFail",
            "EnsureElephants",
            "ConsumeChicken",
            "PatRaichus",
            "DeletingFiles",
            "DownloadingRAM",
            "Calling911",
            "SettingGrassOnFire",
            "PuttingOutGrassFires",
            "StillAlive",
            "EatingFood"
        };
        private readonly string[] _complaints = new string[]
        {
            "Why won't these tests finish!",
            "Are these even running?!",
            "I guess this is my life now",
            "I wanna go home",
            "Surely they will be done soon"
        };
    }
}
