using UnityEngine;

namespace Code.Weapons
{
    public static class RigidbodyHelper
    {
        public static Rigidbody GetOrAddRigidbody(Collider collider)
        {
            if (!collider.TryGetComponent(out Rigidbody rigidbody))
            {
                rigidbody = collider.gameObject.AddComponent<Rigidbody>();
            }

            return rigidbody;
        }
    }
}
