using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(SphereCollider))]
public class ScanerTrigger : AbstractScan
{
    [SerializeField] private Entity _bazeEntity;
    private SphereCollider _collider;
    private bool _scane;
    private Action<Entity> _action;
    private void OnTriggerEnter(Collider other)
    {
        if (_scane == true)
        {
            if (other.transform.gameObject.TryGetComponent<Mark>(out Mark mark))
            {
                Entity entity = mark.GetEntity();
                if (_bazeEntity.Equals(entity)==false)
                {
                    _action.Invoke(entity);
                }
            }
        }
     
    }

    private void Start()
    {
        _collider = this.GetComponent<SphereCollider>();
    }

    public override void Scan(float range, Action<Entity> detectEntity)
    {
        _scane = true;
        _action = detectEntity;
        
    }

    public override void EndScan()
    {
        _scane = false;
    }
}
