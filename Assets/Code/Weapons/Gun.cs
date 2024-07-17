using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Code.Weapons
{
    public sealed class Gun : Weapon
    {
        [SerializeField] private Bullet bulletPrefab;
        [SerializeField] private int countInClip;
        [SerializeField] private float fireDelay = 1f;

        private Transform _bulletRoot;
        private readonly Queue<Bullet> _bullets = new();

        private bool _canShoot = true;

        protected override void Start()
        {
            base.Start();
            _bulletRoot = new GameObject("BulletRoot").transform;
        }

        public override void Fire()
        {
            if (!_canShoot || !CanShoot)
            {
                return;
            }

            if (_bullets.TryDequeue(out Bullet bullet))
            {
                bullet.Run(barrel.forward * Force, barrel.position, OnDestroyBullet);
                StartCoroutine(FireCooldown());
                LastShotTime = 0.0f;
            }
        }

        private IEnumerator FireCooldown()
        {
            _canShoot = false;
            yield return new WaitForSeconds(fireDelay);
            _canShoot = true;
        }

        private void OnDestroyBullet(GameObject anotherGameObject)
        {
            Destroy(anotherGameObject);
        }

        public override void Reload()
        {
            for (int i = 0; i < countInClip; i++)
            {
                if (_bullets.Count == countInClip)
                {
                    return;
                }

                Bullet instantiate = Instantiate(bulletPrefab, _bulletRoot);
                instantiate.Sleep();

                _bullets.Enqueue(instantiate);
            }
        }
    }
}