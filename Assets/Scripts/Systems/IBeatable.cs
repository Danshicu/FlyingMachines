using Weapons.Shootables;

namespace Systems
{
    public interface IBeatable
    {
        public void TakeDamage(IShootable shootable);
    }
}