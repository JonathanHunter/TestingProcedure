namespace Assets.Scripts.Management
{
    using UnityEngine;

    public class BG : MonoBehaviour
    {
        private void Start()
        {
            DontDestroyOnLoad(this.gameObject);
        }
    }
}
