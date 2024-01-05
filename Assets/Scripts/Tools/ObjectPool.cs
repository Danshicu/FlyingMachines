using System.Collections.Generic;
using UnityEngine;

namespace Tools
{
   public class ObjectPool : MonoBehaviour
   {
      [SerializeField] private PoolSettings _settings;
      private List<Poolable> _pool = new List<Poolable>();
      
      public void SpawnItems()
      {
         for (int i = 0; i < _settings.Count; i++)
         {
            _pool.Add(CreateItem());
         }
      }

      private Poolable CreateItem()
      {
         Poolable poolable = (Poolable)GameObject.Instantiate((UnityEngine.Object)((object)_settings.Poolable));
         poolable.SetActive(false);
         return poolable;
      }

      public bool HasFreeElement(out Poolable free)
      {
         free = null;
         foreach (var item in _pool)
         {
            if (!item.IsActive())
            {
               free = item;
               return true;
            }
         }
         return false;
      }

      public bool TryGetFree(out Poolable item)
      {
      
         if (!HasFreeElement(out item))
         {
            if (!_settings.IsExpandable) return false;
            item = CreateItem();
            _pool.Add(item);
         }
         return true;
      }
   
   }
}
