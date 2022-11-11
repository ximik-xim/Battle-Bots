using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicCube : MonoBehaviour
{
    [SerializeField] private CubeEntity _cube;
    private CubeHaracteristic _currentHaracteristic;
    private ControlEntity _controlEntity;

    private CubeHaracteristic _haracteristicTarget;
    private Entity _entity;

    private void Start()
    {
        _controlEntity.SearchEnemy(_currentHaracteristic.DetectionRange,DetectEnemy);
        _currentHaracteristic = _cube.CubeHaracteristic;
    }

    
    private void DetectEnemy(Entity entity)
    {
       
        if (CheckTargetHp(entity))
        {
            _controlEntity.EndSearchEnemy();
            _controlEntity.MoveTarget(entity, CloseEnemy,_currentHaracteristic.RangeAttake,_currentHaracteristic.MoveSpeed);//вот тут нужно решить вопрос, где будет храниться параметры
           
            return;
        } 
        
        _controlEntity.SearchEnemy(_currentHaracteristic.DetectionRange,DetectEnemy);
    }
    
    private void CloseEnemy()
    {
        if (CheckHaractericsic())
        { 
            //_fas.EndMove();//в случае если останавливаемся перед атакой
            _controlEntity.AttackTarget(_entity, _currentHaracteristic.RangeAttake / 2, _currentHaracteristic.Damage, EndAttack);
            return;
        }
        
        _controlEntity.SearchEnemy(_currentHaracteristic.DetectionRange,DetectEnemy);
    }
    
    private void EndAttack(Entity entity)
    {
        if (CheckHaractericsic())
        {
            _controlEntity.MoveTarget(entity, CloseEnemy, _currentHaracteristic.RangeAttake / 2, _currentHaracteristic.MoveSpeed);
            return;
        }
   
        _controlEntity.SearchEnemy(_currentHaracteristic.DetectionRange, DetectEnemy);
    }
    private bool CheckTargetHp(Entity entity)
    {
        if (entity != _entity)
        {
            _entity = _entity;
        }

       return CheckHaractericsic();
    }

    private bool CheckHaractericsic()
    {
        if (_haracteristicTarget.Hp <= 0)
        {
            _entity = null;
            return false;
        }

        return true;
    }
}
