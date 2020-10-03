namespace Assets.Scripts.Character.Bullets
{
    using UnityEngine;

    public abstract class Bullet : CharacterComponent
    {
        public float lifetime;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            _hit = true;
        }

        protected override void Init()
        {
            Reset();
        }

        protected override void Run()
        {
            BulletRun();

            if ((_time += Time.deltaTime) > lifetime || _hit)
                this.gameObject.SetActive(false);
        }

        public void Reset()
        {
            _time = 0;
            _hit = false;
            BulletReset();
        }

        protected abstract void BulletReset();
        protected abstract void BulletRun();

        private float _time;
        private bool _hit;
    }
}
