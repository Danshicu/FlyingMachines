using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Tools;

[CreateAssetMenu(fileName = "Pool Settings", menuName = "Pool/Settings", order = 1)]
public class PoolSettings : ScriptableObject
{
    public Poolable Poolable;
    public int Count;
    public bool IsExpandable;
   
}
