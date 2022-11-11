using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeHaracteristic : Haracteristic
{
  
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

    public TypeRole Role => _typeRole;
    
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _damage;
    [SerializeField] private float _rangeAttack;
    [SerializeField] private float _detectionRange;
    [SerializeField] private TypeRole _typeRole;
    
    public enum TypeRole
    {
        None,
        Tank,
        Damage,
        Runner
    }
}
