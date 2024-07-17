using System;
using System.Collections;
using UnityEngine;

namespace Code.Weapons
{
    public sealed class Bazuka : Weapon
    {
        [SerializeField] private Rocket rocketPrefab;
        
        private Rocket _instantiateRocket;

        private Coroutine _reloadRoutine;

        private void OnDisable()
        {
            _reloadRoutine = null;
        }

        public override void Fire()
        {
            if (_instantiateRocket)
            {
                _instantiateRocket.Run(barrel.forward * Force);
                _instantiateRocket = null;
            }
        }

        public override void Reload()
        {
            if (_instantiateRocket != null)
            {
                return;
            }
            
            if (_reloadRoutine == null)
                _reloadRoutine = StartCoroutine(ReloadRoutine());
        }

        private IEnumerator ReloadRoutine()
        {
            yield return new WaitForSeconds(1);
            
            _instantiateRocket = Instantiate(rocketPrefab);
            _instantiateRocket.Sleep(barrel.position);

            _reloadRoutine = null;
        }

        protected override void SetActiveInternal(bool isActive)
        {
            base.SetActiveInternal(isActive);
            
            if (_instantiateRocket == null)
            {
                return;
            }
            
            _instantiateRocket.gameObject.SetActive(isActive);
        }
    }
}
