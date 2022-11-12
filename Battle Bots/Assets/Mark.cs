using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Mark : MonoBehaviour
{
    [SerializeField] 
    private Entity _entity;
    
    public Entity GetEntity()
    {
        return _entity;
    }
}
