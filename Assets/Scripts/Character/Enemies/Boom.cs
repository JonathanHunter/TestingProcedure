namespace Assets.Scripts.Character.Enemies
{
    using UnityEngine;

    public class Boom : MonoBehaviour
    {
        public AudioSource sfx;

        private void Update()
        {
            if (!sfx.isPlaying)
                Destroy(this.gameObject);
        }
    }
}
