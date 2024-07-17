using System;
using UnityEngine;

namespace Code.Weapons
{
    public sealed class Bullet : MonoBehaviour
    {
        [SerializeField] private float force;
        
        private Rigidbody _rigidbody;
        
        private Action<GameObject> _onDestroy;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void OnBecameInvisible()
        {
            _onDestroy?.Invoke(gameObject);
        }

        private void OnCollisionEnter(Collision other)
        {
            Rigidbody otherRigidbody = RigidbodyHelper.GetOrAddRigidbody(other.collider);
            otherRigidbody.AddForce(_rigidbody.velocity * force, ForceMode.Impulse);
            
            _onDestroy?.Invoke(gameObject);
        }

        public void Run(Vector3 path, Vector3 startPoint, Action<GameObject> onDestroy)
        {
            _onDestroy = onDestroy;
            
            transform.position = startPoint;
            gameObject.SetActive(true);
            
            _rigidbody.WakeUp();
            _rigidbody.AddForce(path);
        }

        public void Sleep()
        {
            _rigidbody.Sleep();
            
            gameObject.SetActive(false);
        }
    }
}
