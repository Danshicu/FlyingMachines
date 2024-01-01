using Tools;
using UnityEngine;
using Weapons.Shootables;

namespace Weapons
{
    public class LaserProjectileWeapon : Weapon
    {
        [SerializeField] private float _pushingForce;
        [SerializeField] private ObjectPool _objectPool;  
        public override void Shoot()
        {
            if (_objectPool.TryGetFree(out Poolable projectile))
            {
                var thisTransform = transform;
                var projectileTransform = projectile.transform;
                projectileTransform.position = thisTransform.position;
                projectileTransform.localRotation = thisTransform.rotation;
                ((IShootable)projectile).Rigidbody().AddForce(thisTransform.forward*_pushingForce);
            }
        }

        // Start is called before the first frame update
        void Start()
        {
            _objectPool.SpawnItems();
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Shoot();
            }
        }
    }
}
