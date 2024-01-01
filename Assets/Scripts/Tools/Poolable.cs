using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tools
{
    public abstract class Poolable : MonoBehaviour
    {
        public virtual bool IsActive() => gameObject.activeInHierarchy;

        public virtual void SetActive(bool value){gameObject.SetActive(value);}
        
    }
}

