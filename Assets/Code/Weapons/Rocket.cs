using UnityEngine;

namespace Code.Weapons
{
    public sealed class Rocket : MonoBehaviour
    {
        [SerializeField] private float powerExplosion;
        [SerializeField] private float scale;
        
        private Rigidbody _rigidbody;
        
        private readonly Collider[] _collidedObjects = new Collider[CollidedObjectSize];
        
        private const int CollidedObjectSize = 128;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void OnBecameInvisible()
        {
            Destroy(gameObject);
        }
        
        private void OnCollisionEnter(Collision other)
        {
            Vector3 center = other.contacts[0].point;
            float radius = scale / 2;
            
            int countCollied = Physics.OverlapSphereNonAlloc(center, radius, _collidedObjects);
            
            for (var i = 0; i < countCollied; i++)
            {
                Collider collidedObject = _collidedObjects[i];
                
                Rigidbody otherRigidbody = RigidbodyHelper.GetOrAddRigidbody(collidedObject);
                otherRigidbody.AddExplosionForce(powerExplosion, center, radius);
            }
            
            Destroy(gameObject);
        }

        public void Run(Vector3 path)
        {
            _rigidbody.WakeUp();
            _rigidbody.isKinematic = false;
            _rigidbody.AddForce(path);
        }

        public void Sleep(Vector3 startPoint)
        {
            _rigidbody.Sleep();
            _rigidbody.isKinematic = true;
            
            transform.position = startPoint;
        }
    }
}
