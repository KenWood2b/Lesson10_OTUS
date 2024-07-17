using UnityEngine;

namespace Code.Weapons.Data
{
    [CreateAssetMenu(fileName = nameof(WeaponDataConfig), menuName = "Data/Weapons/Data")]
    public sealed class WeaponDataConfig : ScriptableObject
    {
        [SerializeField] private float force;
        [SerializeField] private float shootDelay;
        
        public float Force => force;
        public float ShootDelay => shootDelay;
    }
}
