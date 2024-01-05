using System;
using UnityEngine;

namespace Weapons
{
    [Serializable]
    public class Cooldown
    {
        [SerializeField] private float _cooldownTime;
        private float _nextFireTime;
        public bool IsReady => Time.time > _nextFireTime;
        public void StartCooldown() => _nextFireTime = Time.time + _cooldownTime;
    }
}