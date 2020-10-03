namespace Assets.Scripts.Character.Player
{
    using UnityEngine;

    public class Movement : CharacterComponent
    {
        public Rigidbody2D rgbdy;
        public float speed;

        protected override void Init()
        {
            
        }

        protected override void Run()
        {
            Vector2 vel = new Vector2();
            if (Input.GetKey(KeyCode.W))
            {
                vel += Vector2.up;
            }

            if (Input.GetKey(KeyCode.S))
            {
                vel += Vector2.down;
            }

            if (Input.GetKey(KeyCode.A))
            {
                vel += Vector2.left;
            }

            if (Input.GetKey(KeyCode.D))
            {
                vel += Vector2.right;
            }

            rgbdy.velocity = vel * speed;
        }
    }
}
