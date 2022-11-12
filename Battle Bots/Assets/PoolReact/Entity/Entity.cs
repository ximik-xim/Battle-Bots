using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public abstract class Entity : PoolReact
{
    [SerializeField]
    private UnityEvent<float> _updateHp;
    public float Hp
    {
        get => _Hp;
        private set
        {
            _Hp = value;
            
            if (_Hp <= 0)
            {
                _Hp = 0;
                gameObject.SetActive(false);
            }
        }
        
    }
    
    [SerializeField] private float _Hp;
    
    public void SetHara(Haracteristic haracteristic)
    {
        _Hp = haracteristic.Hp;
    }

    public void TakeDamage(float damage)
    {
        Hp -= damage;
    }
    
    public void Kill()
    {
        Hp = 0;
    }
    
}
