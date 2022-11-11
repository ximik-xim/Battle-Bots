using System;
using UnityEngine;
using Random = UnityEngine.Random;

public abstract class DicteneryElementFabric<T,K> : PoolFabric<T,K> where T : PoolReact where K : Enum 
{
    [SerializeField] 
    protected SerializeDictionary<K, T> serializeDictionary;

    private void Start()
    {
        serializeDictionary.Initialization();
        StartObject();
    }

    protected virtual void StartObject()
    {
        
    } 
    // public override void Spawn(K type, int count, Vector3 position)
    // {
    //
    //     for (int i = 0; i < _pool.DisavleObject.Count; i++)
    //     {
    //         if()
    //     }
    //     
    //     for (int i = 0; i < count; i++)
    //     {
    //         di
    //         
    //         
    //     }
    // }


    // protected T RandomTypeEnum()
    // {
    //     int countElementType = Enum.GetNames(typeof(K)).Length;
    //     int idType = Random.Range(1, countElementType); //Рандом с 1 т.к 0 знач всегда должно быть None в enum
    //     K type = (K)Enum.GetValues(typeof(K)).GetValue(idType);
    //     T prefabEntity = _eb[type];
    //     
    //     return prefabEntity;
    // }
}
