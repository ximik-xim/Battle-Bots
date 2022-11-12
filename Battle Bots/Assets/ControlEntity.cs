using System;
using UnityEngine;

public class ControlEntity : MonoBehaviour
{
  [SerializeField]  private AbstractAttack _attack;
   [SerializeField] private AbstractMove _move;
   [SerializeField] private AbstractScan _scan;

   public void SearchEnemy(float range, Action<Entity> detectEntity)
    {
        _move.Patrolling();
        _scan.Scan(range,detectEntity);
    }

    public void EndSearchEnemy()
    {
        _move.Stop();
        _scan.EndScan();
    }

    public void MoveTarget(Entity target, Action action,float distanceTarget,float moveSpeed)
    {
        _move.MoveTarget(target.transform,distanceTarget,action,moveSpeed);
    }

    public void EndMove()
    {
        _move.Stop();
    }

    public void AttackTarget(Entity target,float distanceAttack,float damage,Action<bool> endAttack)
    {
        _attack.Attack(target,distanceAttack,damage,endAttack);
    }

    public void StopAttack()
    {
        _attack.StopAttack();
    }
}
