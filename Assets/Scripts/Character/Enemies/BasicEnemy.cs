using UnityEngine;

namespace Assets.Scripts.Character.Enemies
{
    public class BasicEnemy : CharacterComponent
    {
        public Rigidbody2D rgbd;
        public float speed;

        protected override void Init()
        {
            speed = Random.Range(speed, speed * 2);
        }

        protected override void Run()
        {
            rgbd.velocity = Vector2.down * speed;
        }
    }
}
