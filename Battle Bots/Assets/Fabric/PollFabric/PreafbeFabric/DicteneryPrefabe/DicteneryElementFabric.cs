using System;
using UnityEngine;
using Random = UnityEngine.Random;

public abstract class DicteneryElementFabric<K,T> : PoolFabric<K,T> where T : PoolReact where K : Enum 
{
    [SerializeField] 
    protected SerializeDictionary<K, T> _dataDictionary;

}
