using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeEntity : Entity
{
    public enum TypeCube
    {
        None,
        Blue,
        Red,
        Green
    }
    
    public TypeCube Type
    {
        get => _typeCube;
    }

    [SerializeField]
    private TypeCube _typeCube;
    public CubeHaracteristic CubeHaracteristic { get; private set; }

    public void SetHar(CubeHaracteristic haracteristic)
    {
        CubeHaracteristic = haracteristic;
    }
}
