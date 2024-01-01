using System;
using Tools;
using Unity.VisualScripting;
using UnityEngine;

namespace Weapons.Shootables
{
    [RequireComponent(typeof(Rigidbody))]
    public class LaserProjectile :  Poolable, IShootable
    {
        private Rigidbody _rigidbody;
        
        private void OnEnable()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }
        
        public override bool IsActive()
        {
            return gameObject.activeInHierarchy;
        }

        public override void SetActive(bool value)
        {
            gameObject.SetActive(value);
        }

        public Rigidbody Rigidbody()
        {
            return _rigidbody;
        }
    }
}