namespace Assets.Scripts.Character.Player
{
    using Bullets;
    using UnityEngine;

    public class Weapon : CharacterComponent
    {
        public Transform barrel;
        public Bullet bullet;
        public int clip;
        public float shotDelay;
        public AudioSource sfx;

        protected override void Init()
        {
            _bullets = new Bullet[clip];
            for (int i = 0; i < clip; i++)
            {
                Bullet b = Instantiate(bullet);
                b.gameObject.SetActive(false);
                _bullets[i] = b;
            }
        }

        protected override void Run()
        {
            if ((_delay -= Time.deltaTime) < 0 && Input.GetKey(KeyCode.Space))
            {
                _delay = shotDelay;
                if (!_bullets[_currentBullet].gameObject.activeSelf)
                {
                    sfx.Play();
                    Bullet b = _bullets[_currentBullet];
                    b.transform.position = barrel.position;
                    b.transform.rotation = barrel.rotation;
                    b.gameObject.SetActive(true);
                    b.Reset();

                    _currentBullet++;
                    if (_currentBullet >= clip)
                        _currentBullet = 0;
                }
            }
        }

        private Bullet[] _bullets;
        private int _currentBullet;
        private float _delay;
    }
}
