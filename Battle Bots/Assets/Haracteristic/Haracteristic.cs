using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Haracteristic : ScriptableObject
{
    public float Hp
    {
        get => _Hp;
    }
    
    [SerializeField] private float _Hp;
    


    
    
}
