using System;
using System.IO;
using UnityEngine;

namespace Code.Weapons.Data
{
    [CreateAssetMenu(fileName = nameof(WeaponUpgradeDataConfig), menuName = "Data/Weapons/UpgradeData")]
    public sealed class WeaponUpgradeDataConfig : ScriptableObject
    {
        [Serializable]
        private sealed class WeaponUpgradeDada
        {
            [field: SerializeField]
            public WeaponDataConfig WeaponDataConfig { get; private set; }
            
            [field: SerializeField]
            public int Level { get; private set; }
        }
        
        [SerializeField] private WeaponUpgradeDada[] upgradeDada;
        
        public WeaponDataConfig GetWeaponDataConfig(int level)
        {
            for (var index = 0; index < upgradeDada.Length; index++)
            {
                WeaponUpgradeDada weaponUpgrade = upgradeDada[index];
                
                if (weaponUpgrade.Level == level)
                {
                    return weaponUpgrade.WeaponDataConfig;
                }
            }

            throw new InvalidDataException($"Not found weapon data for level {level}");
        }
    }
}
