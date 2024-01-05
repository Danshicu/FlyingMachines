using Tools;
using UnityEngine;
using Weapons.Shootables;

namespace Weapons
{
    public class LaserProjectileWeapon : Weapon
    {
        [SerializeField] private Cooldown _cooldown;
        [SerializeField] private AudioSource _audioSoure;
        [SerializeField] private float _pushingForce;
        [SerializeField] private ObjectPool _objectPool;  
        public override void Shoot()
        {
            if (_objectPool.TryGetFree(out Poolable projectile) && _cooldown.IsReady)
            {
                var thisTransform = transform;
                var projectileTransform = projectile.transform;
                projectileTransform.position = thisTransform.position;
                projectileTransform.localRotation = thisTransform.rotation;
                projectile.SetActive(true);
                ((Projectile)projectile).Rigidbody.AddForce(thisTransform.forward*_pushingForce);
                _cooldown.StartCooldown();
                _audioSoure.Play();
            }
        }

        // Start is called before the first frame update
        void Start()
        {
            _audioSoure = GetComponent<AudioSource>();
            _objectPool.SpawnItems();
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButton(0))
            {
                Shoot();
            }
        }
    }
}
