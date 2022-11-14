using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointSpawn : MonoBehaviour
{
    [SerializeField] 
    private SpawnFabric<CubeEntity.TypeCube> _fabric;
    [SerializeField]
    private int _countStartSpawn;
    [SerializeField]
    private int _countClickSpawn;
    [SerializeField]
    private CubeEntity.TypeCube _typeCube;

    private void Start()
    {
        _fabric.Spawn(_typeCube,_countStartSpawn,transform.position);
    }

    private void OnMouseDown()
    {
        _fabric.Spawn(_typeCube,_countClickSpawn,transform.position);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, 1f);
    }
    
}
