using System;
using System.Collections;
using NaughtyAttributes;
using Tools;
using Unity.VisualScripting;
using UnityEngine;

namespace Weapons.Shootables
{
    
    public class LaserProjectile :  Projectile, IDespawnableOnLifetime
    {
        
        [SerializeField] private float _lifetime;
        private Coroutine _despawnCoroutine;
        
        private void OnEnable()
        {
            EnableLogic();
            if (_despawnType.HasFlag(DespawnType.OnLifetimeEnd))
            {
                _despawnCoroutine = StartCoroutine(DespawnOnLifetime(_lifetime));
            }
        }
        
        public override void Despawn()
        {
            if (gameObject.activeInHierarchy)
            {
                _rigidbody.velocity = Vector3.zero;
                _rigidbody.angularVelocity = Vector3.zero;
                gameObject.SetActive(false);
            }

            _despawnCoroutine = null;
        }
        
        public IEnumerator DespawnOnLifetime(float lifetime)
        {
            yield return new WaitForSeconds(lifetime);
            Despawn();
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.TryGetComponent(out HealthSystem enemy))
            {
                enemy.TakeDamage(this);
            }
            Despawn();
        }
    }
}