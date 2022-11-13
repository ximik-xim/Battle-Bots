using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public abstract class Entity : PoolReact
{  
    public float Hp
    {
        get => _Hp;
        private set
        {
            _Hp = value;

            if (_isKill == false)
            {
                if (_Hp <= 0)
                {
                    _Hp = 0;

                    killThisEntity?.Invoke();
                    gameObject.SetActive(false);
                    _isKill = true;
                }
            }

        }

    }
    [SerializeField]
    private UnityEvent<float> _updateHp;
    [SerializeField] 
    private UnityEvent<float> _updateMaxHeal;
    [SerializeField] 
    private float _Hp;
    
    private Action killThisEntity;
    private bool _isKill = false;
   
    
    public void SetHara(Haracteristic haracteristic)
    {
        _isKill = false;
        _Hp = haracteristic.Hp;
        _updateMaxHeal.Invoke(Hp);
    }

    public void TakeDamage(float damage,Action action)
    {
        killThisEntity = action;
        Hp -= damage;
        _updateHp.Invoke(Hp);
    }
    
    public void Kill(Action action)
    {
        Hp = 0;
    }

}
