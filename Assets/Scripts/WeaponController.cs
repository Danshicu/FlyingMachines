using System;
using System.Collections.Generic;
using Tools;
using UnityEngine;
using UnityEngine.InputSystem;
using Weapons;
using Zenject;

namespace DefaultNamespace
{
    public class WeaponController : MonoInstaller
    {
        [SerializeField] private PoolSettings _settings;
        [SerializeField] private List<Weapon> _weapons;
        private ObjectPool _objectPool;

        // public override void InstallBindings()
        // {
        //     Debug.Log("Installer Called");
        //     _objectPool = new ObjectPool(_settings);
        //     _objectPool.SpawnItems();
        //     Container.Bind<ObjectPool>().To<ObjectPool>().AsSingle();
        // }

        public void StartControlWeapons(InputAction shootAction)
        {
            _objectPool = gameObject.AddComponent<ObjectPool>();
            _objectPool.BindSettings(_settings);
             //_objectPool = new ObjectPool(_settings);
             _objectPool.SpawnItems();
             foreach (var weapon in _weapons)
             {
                 Debug.Log("Iterating weapons");
                 weapon.SetShootEvent(shootAction);
                 if (weapon.UsePool)
                 {
                     weapon.SetLaserPool(_objectPool);
                     Debug.Log("AddingObjectPool");
                 }
             }
        }
        
    }
}