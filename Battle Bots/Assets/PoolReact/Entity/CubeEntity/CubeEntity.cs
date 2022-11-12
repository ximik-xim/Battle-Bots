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

    public float MoveSpeed
    {
        get => _moveSpeed;
    }
    public float Damage
    {
        get => _damage;
    }
    public float RangeAttake
    {
        get => _rangeAttack;
    }
    public float DetectionRange
    {
        get => _detectionRange;
    }

    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _damage;
    [SerializeField] private float _rangeAttack;
    [SerializeField] private float _detectionRange;

    public TypeCube CubeType
    {
        get => _typeCube;
    }

    [SerializeField]
    private TypeCube _typeCube;
    
    public void SetHar(CubeHaracteristic haracteristic)
    {
        SetHara(haracteristic);

        _moveSpeed = haracteristic.MoveSpeed;
        _damage = haracteristic.Damage;
        _rangeAttack = haracteristic.RangeAttake;
        _detectionRange = haracteristic.DetectionRange;
    }

    public override bool Equals(object other)
    {
        if (other.GetType()==this.GetType())
        {
            CubeEntity entity = (CubeEntity) other;
            if (entity.CubeType == this.CubeType)
            {
                return true;
            }
        }

        return false;
    }
}
