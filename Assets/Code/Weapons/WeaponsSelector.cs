using UnityEngine;

namespace Code.Weapons
{
    internal sealed class WeaponsSelector
    {
        private readonly Weapon[] _weapons;
        
        private Weapon _currentWeapon;
        private int _currentIndex;

        public WeaponsSelector(Weapon[] weapons)
        {
            _weapons = weapons;
            
            for (int i = 0; i < weapons.Length; i++)
            {
                Weapon weapon = weapons[i];
                weapon.SetActive(false);
            }
        }

        public void Next()
        {
            _currentIndex++;
            SelectWeapon();
        }

        public void Previous()
        {
            _currentIndex--;
            SelectWeapon();
        }

        public void Fire()
        {
            if (_currentWeapon != null)
            {
                _currentWeapon.Fire();
            }
        }

        public void Reload()
        {
            if (_currentWeapon != null)
            {
                _currentWeapon.Reload();
            }
        }

        private void SelectWeapon()
        {
            if (_currentWeapon != null)
            {
                _currentWeapon.SetActive(false);
            }

            int index = Mathf.Abs(_currentIndex % _weapons.Length);
            _currentWeapon = _weapons[index];
            _currentWeapon.SetActive(true);
        }
    }
}
