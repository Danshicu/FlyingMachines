using System;
using System.Collections;
using NaughtyAttributes;
using Tools;
using Unity.VisualScripting;
using UnityEngine;
using Tools;

namespace Weapons.Shootables
{
    [RequireComponent(typeof(Rigidbody))]
    public abstract class Projectile : Poolable, IShootable
    {
        public Rigidbody Rigidbody=> _rigidbody;
        [SerializeField, EnumFlags] protected DespawnType _despawnType;
        [SerializeField] protected int _damage;
        
        protected Rigidbody _rigidbody;
        public int Damage => _damage;

        protected void EnableLogic()
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
        
        public virtual void Despawn()
        {
            throw new NotImplementedException();
        }
    }
}