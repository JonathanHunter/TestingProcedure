namespace Assets.Scripts.UI
{
    using UnityEngine;
    using UnityEngine.SceneManagement;

    public class Main : MonoBehaviour
    {
        public void Play()
        {
            SceneManager.LoadScene("Start");
        }

        public void Exit()
        {
            Application.Quit();
        }
    }
}
