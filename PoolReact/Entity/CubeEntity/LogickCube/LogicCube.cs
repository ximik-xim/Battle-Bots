using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LogicCube : MonoBehaviour
{ 
    [SerializeField] private CubeEntity _cube;
    [SerializeField] private ControlEntity _controlEntity;
    [SerializeField] private UnityEvent<int> _killEntity;
    private int _countKill;
    
    private Entity _entity;

    private void OnEnable()
    {
        _countKill = 0;
        _killEntity.Invoke(0);
    }

    private void Start()
    { 
        _controlEntity.SearchEnemy(_cube.DetectionRange,DetectEnemy);
    }
    
    private void DetectEnemy(Entity entity)
    {
        if (CheckTargetHp(entity))
        {
            _controlEntity.EndSearchEnemy();
            _controlEntity.MoveTarget(entity, MoveToEnemy,_cube.RangeAttake,_cube.MoveSpeed);
            
            return;
        } 
        
        _controlEntity.SearchEnemy(_cube.DetectionRange,DetectEnemy);
    }
    
    private void MoveToEnemy()
    {
        if (CheckHaractericsic())
        { 
            //_fas.EndMove();//в случае если останавливаемся перед атакой
            _controlEntity.AttackTarget(_entity, _cube.RangeAttake / 2, _cube.Damage, EndAttack,KillEntity);
            return;
        }
        
        _controlEntity.SearchEnemy(_cube.DetectionRange,DetectEnemy);
    }
    
    private void EndAttack(bool attackEnd)
    {
        if (CheckHaractericsic())
        {
            _controlEntity.MoveTarget(_entity, MoveToEnemy, _cube.RangeAttake / 2, _cube.MoveSpeed);
            return;
        }
        
        _controlEntity.SearchEnemy(_cube.DetectionRange, DetectEnemy);
    }
    private bool CheckTargetHp(Entity entity)
    {
        if (_entity != entity)
        {
            _entity = entity;
        }

       return CheckHaractericsic();
    }

    private bool CheckHaractericsic()
    {
        if (_entity.Hp <= 0)
        {
            _entity = null;
            return false;
        }

        return true;
    }

    private void KillEntity()
    {
        _countKill++;
        _killEntity.Invoke(_countKill);
    }
}
