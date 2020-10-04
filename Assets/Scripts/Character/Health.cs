namespace Assets.Scripts.Character
{
    using UnityEngine;

    public class Health : CharacterComponent
    {
        public int maxHealth;
        public int health;

        public GameObject[] sprites;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            _tookHit = true;
        }

        protected override void Init()
        {
            _tookHit = false;
            health = maxHealth;
        }

        protected override void Run()
        {
            if (_tookHit)
            {
                if ((maxHealth - health) < sprites.Length)
                    sprites[maxHealth - health].SetActive(true);

                _tookHit = false;
                health--;

                if (health < 1)
                    Destroy(this.gameObject);                    
            }
        }

        private bool _tookHit;
    }
}
