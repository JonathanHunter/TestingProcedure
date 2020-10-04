namespace Assets.Scripts.Character.Bullets
{
    using UnityEngine;

    public class BasicBullet : Bullet
    {
        public Rigidbody2D rgbd;
        public float speed;

        protected override void BulletReset()
        {
        }

        protected override void BulletRun()
        {
            rgbd.velocity = transform.right * speed;
        }
    }
}
