namespace Assets.Scripts.Character.Bullets
{
    using UnityEngine;

    public abstract class Bullet : CharacterComponent
    {
        public float lifetime;

        protected override void Init()
        {
            Reset();
        }

        protected override void Run()
        {
            BulletRun();

            if ((_time += Time.deltaTime) > lifetime)
                this.gameObject.SetActive(false);
        }

        public void Reset()
        {
            _time = 0;
            BulletReset();
        }

        protected abstract void BulletReset();
        protected abstract void BulletRun();

        private float _time = 0;
    }
}
