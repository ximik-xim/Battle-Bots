using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CubeFabric : EntityFabric<CubeEntity.TypeCube, CubeEntity>
{
   [SerializeField]
    private SerializeDictionary<CubeHaracteristic.TypeRole, CubeHaracteristic> _haracteristics;

    private void Awake()
    {
        serializeDictionary.Initialization();
        _haracteristics.Initialization();
    }

    public override void Spawn(CubeEntity.TypeCube type, int count, Vector3 position)
    {
        int countEntity = 0;
        for (int i = 0; i <_pool.DisavleObject.Count ; i++)
        {
            if (_pool.DisavleObject[i].CubeType == type)
            {
                _pool.DisavleObject[i].SetHar(RandomTypeEnum());
                _pool.DisavleObject[i].gameObject.SetActive(true);
                _pool.DisavleObject[i].gameObject.transform.position = position;

                countEntity++;
                if (countEntity == count)
                {
                    return;
                }
            }
        }
        
        for (int i = countEntity; i < count; i++)
        {
           var entity = InstantiatePrefabe(serializeDictionary[type]);
           entity.gameObject.transform.position = position;
        }
        
    }
    
    protected CubeHaracteristic RandomTypeEnum()
    {
        int countElementType = Enum.GetNames(typeof(CubeHaracteristic.TypeRole)).Length;
        int idType = Random.Range(1, countElementType); 
        CubeHaracteristic.TypeRole type = (CubeHaracteristic.TypeRole)Enum.GetValues(typeof(CubeHaracteristic.TypeRole)).GetValue(idType);
        CubeHaracteristic prefabEntity = _haracteristics[type];
        
        return prefabEntity;
    }

    public void Spawn(CubeEntity.TypeCube type, CubeHaracteristic.TypeRole role, int count, Vector3 position)
    {
        
    }

    protected override void AddParametersInstantiatePrefabe(CubeEntity cubeEntity)
    {
        cubeEntity.SetHar(RandomTypeEnum());
    }
}
