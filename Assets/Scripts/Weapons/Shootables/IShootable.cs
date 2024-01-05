using UnityEngine;

namespace Weapons.Shootables
{
    public interface IShootable
    {
        public Rigidbody Rigidbody=>null;
        public void Despawn();
        public int Damage => 0;
    }
}