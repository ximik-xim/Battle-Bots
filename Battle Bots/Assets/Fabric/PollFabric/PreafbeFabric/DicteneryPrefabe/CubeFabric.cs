using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeFabric : EntityFabric<CubeEntity,CubeEntity.TypeCube>
{
   [SerializeField]
    private SerializeDictionary<CubeHaracteristic.TypeRole, CubeHaracteristic> _haracteristics;
    protected override void StartObject()
    {
        _haracteristics.Initialization();
    }

    public override void Spawn(CubeEntity.TypeCube type, int count, Vector3 position)
    {
        
    }

    public void Spawn(CubeEntity.TypeCube type, CubeHaracteristic.TypeRole role, int count, Vector3 position)
    {
        
    }

    protected override void AddParametersInstantiatePrefabe(CubeEntity cubeEntity)
    {

    }
}
