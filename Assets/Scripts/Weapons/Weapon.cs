using System;
using Tools;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace Weapons
{
    public abstract class Weapon : MonoBehaviour
    {
        public virtual bool UsePool { get; set; }
        public virtual void Shoot()
        {
        }
        
        [Inject]
        public virtual void SetLaserPool(ObjectPool objectPool) { }
        
        public virtual void SetShootEvent(InputAction shootAction) { }
        
    }
}
