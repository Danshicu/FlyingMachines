using System.Collections;

namespace Weapons.Shootables
{
    public interface IDespawnableOnLifetime
    {
        public IEnumerator DespawnOnLifetime(float lifetime);
    }
}