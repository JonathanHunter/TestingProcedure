namespace Assets.Scripts.Character.Player
{
    using Bullets;
    using UnityEngine;

    public class Weapon : CharacterComponent
    {
        public Transform barrel;
        public Bullet bullet;
        public int clip;

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
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (!_bullets[_currentBullet].isActiveAndEnabled)
                {
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
    }
}
