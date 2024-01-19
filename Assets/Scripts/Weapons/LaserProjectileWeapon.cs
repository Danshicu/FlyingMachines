using System;
using Tools;
using UnityEngine;
using UnityEngine.InputSystem;
using Weapons.Shootables;
using Zenject;

namespace Weapons
{
    public class LaserProjectileWeapon : Weapon
    {
        [field:SerializeField]
        public override bool UsePool
        {
            get;
            set;
        }
        [SerializeField] private Cooldown _cooldown;
        [SerializeField] private AudioSource _audioSoure;
        [SerializeField] private float _pushingForce;
        [SerializeField] private ObjectPool _objectPool;
        private InputAction _shootAction;
        private bool _isShooting;
        
        public override void SetShootEvent(InputAction shootAction)
        {
            _shootAction = shootAction;
            _shootAction.performed += context => _isShooting = true;
            _shootAction.canceled += context => _isShooting=false;
        }
        
        public override void SetLaserPool(ObjectPool objectPool)
        {
            _objectPool = objectPool;
        }
        
        public override void Shoot()
        {
            if (_objectPool.TryGetFree(out Poolable projectile))
            {
                var thisTransform = transform;
                var projectileTransform = projectile.transform;
                projectileTransform.position = thisTransform.position;
                projectileTransform.localRotation = thisTransform.rotation;
                projectile.SetActive(true);
                ((Projectile)projectile).Rigidbody.AddForce(thisTransform.forward*_pushingForce);
                _audioSoure.Play();
            }
        }

        private void Update()
        {
            if (_isShooting && _cooldown.IsReady)
            {
                Shoot();
                _cooldown.StartCooldown();
            }
        }


        // Start is called before the first frame update
        void Start()
        {
            _audioSoure = GetComponent<AudioSource>();
            //_objectPool.SpawnItems();
        }

        // Update is called once per frame

        private void OnDisable()
        {
            
        }
    }
}
