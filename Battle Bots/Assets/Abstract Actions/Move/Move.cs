using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class Move : AbstractMove
{

    [SerializeField] 
    private NavMeshAgent _agent;

    private float _distance;
    private Action _action;
    private Transform _target;
    private Vector3 _targetPosition;

    enum StateMove
    {
        None,
        MoveTarge,
        Patrolling,
        Stop
    }

    private StateMove _state;
    
    public override void Patrolling()
    {
        _agent.isStopped = false;

        _targetPosition = new Vector3(Random.Range(-15, 15), 0, Random.Range(-15, 15));
        _agent.SetDestination(_targetPosition);
        
        _state = StateMove.Patrolling;
    }

    public override void MoveTarget(Transform target, float distance, Action action, float moveSpeed)
    {
        _agent.isStopped = false;
        
        _action = action;
        _distance = distance;
        _target = target;
        
        _agent.speed = moveSpeed;

        _state = StateMove.MoveTarge;
    }

    private void FixedUpdate()
    {
        switch (_state)
        {
            case StateMove.MoveTarge:
            {
                _targetPosition = _target.position;
                _agent.SetDestination(_targetPosition);

                if (_agent.remainingDistance <= _distance)
                {
                    _action?.Invoke();
                    _action = null;
                }
            } break;
            
            case StateMove.Patrolling:
            {
                if (_agent.remainingDistance <= 1)
                {
                    Patrolling();
                }
                
            } break;
        }
        
    }

    public override void Stop()
    {
        _agent.isStopped = true;
        _state = StateMove.Stop;
    }
}
