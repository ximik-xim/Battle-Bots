using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PoolFabric<T,K> : SpawnFabric<K> where T : PoolReact where K : Enum
{
    protected Pool<T> _pool = new Pool<T>();

    protected PoolReact InstantiatePrefabe(T prefabEntity)
    {
        PoolReact entity = Instantiate(prefabEntity, Vector3.zero, Quaternion.identity);
        entity.transform.parent = transform;
        entity.gameObject.SetActive(true);
        _pool.EnableObject.Add((T) entity);
        entity.AddPool(UpdatePool);
        AddParametersInstantiatePrefabe((T) entity);
        
        return entity;
    }

    protected virtual void AddParametersInstantiatePrefabe(T entity)
    {
        
    }
    protected void UpdatePool(bool activeObject,MonoBehaviour monoBehaviour)
    {
        T entity = monoBehaviour as T;  
       
        if (activeObject == true)
        {
            _pool.DisavleObject.Remove(entity);
            _pool.EnableObject.Add(entity);
            return;
        }
       
        _pool.EnableObject.Remove(entity);
        _pool.DisavleObject.Add(entity);
    }
}
