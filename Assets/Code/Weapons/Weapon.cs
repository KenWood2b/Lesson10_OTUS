using Code.Weapons.Data;
using UnityEngine;

namespace Code.Weapons
{
    public abstract class Weapon : MonoBehaviour
    {
        [SerializeField] protected Transform barrel;
        [SerializeField] private WeaponUpgradeDataConfig upgradeDataConfig;
        
        protected bool CanShoot { get; private set; }
        protected float Force { get; private set; }
        
        protected float LastShotTime;
        
        private float _shootDelay;

        protected virtual void Start()
        {
            WeaponDataConfig weaponDataConfig = upgradeDataConfig.GetWeaponDataConfig(1);
            
            Force = weaponDataConfig.Force;
            _shootDelay = weaponDataConfig.ShootDelay;
        }
        
        private void Update()
        {
            CanShoot = _shootDelay <= LastShotTime;
            if (CanShoot)
            {
                return;
            }
            
            LastShotTime += Time.deltaTime;
        }

        public abstract void Fire();
        public abstract void Reload();

        public void SetActive(bool value)
        {
            gameObject.SetActive(value);
            SetActiveInternal(value);
        }

        protected virtual void SetActiveInternal(bool isActive)
        {
            
        }
    }
}
