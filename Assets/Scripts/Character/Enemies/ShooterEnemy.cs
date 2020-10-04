namespace Assets.Scripts.Character.Enemies
{
    using UnityEngine;
    using Bullets;

    public class ShooterEnemy : CharacterComponent
    {
        public Rigidbody2D rgbd;
        public float speed;
        public BasicBullet bullet;
        public Transform[] barrels;
        public float shotDelay;

        protected override void Init()
        {
            speed = Random.Range(speed, speed * 2);
            _timer = Random.Range(0, shotDelay);
        }

        protected override void Run()
        {
            rgbd.velocity = Vector2.down * speed;
            if ((_timer += Time.deltaTime) > shotDelay)
            {
                _timer = 0;
                foreach(Transform barrel in barrels)
                {
                    Bullet b = Instantiate(bullet);
                    b.transform.position = barrel.position;
                    b.transform.rotation = barrel.rotation;
                    b.gameObject.SetActive(true);
                    b.Reset(true);
                }
            }
        }

        private float _timer;
    }
}
