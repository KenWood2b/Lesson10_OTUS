using UnityEngine;

namespace Code.Weapons
{
    public sealed class Player : MonoBehaviour
    {
        private WeaponsSelector _weaponsSelector;

        private const float ScrollThreshold = 0.1f;
        
        private void Start()
        {
            Weapon[] weapons = gameObject.GetComponentsInChildren<Weapon>();
            _weaponsSelector = new WeaponsSelector(weapons);
        }
        
        private void Update()
        {
            float mouseScroll = Input.GetAxis("Mouse ScrollWheel");
            
            if (mouseScroll > 0.1)
            {
                _weaponsSelector.Next();
            }
            if (mouseScroll < -0.1)
            {
                _weaponsSelector.Previous();
            }
            
            if (Input.GetMouseButton(0))
            {
                _weaponsSelector.Fire();
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                _weaponsSelector.Reload();
            }
        }
    }
}
