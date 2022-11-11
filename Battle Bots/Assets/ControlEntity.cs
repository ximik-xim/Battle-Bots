using System;

public class ControlEntity
{
    private AbstractAttack _attack;
    private AbstractMove _move;
    private AbstractScan _scan;
    
    public ControlEntity(AbstractAttack attack,AbstractMove move,AbstractScan scan)
    {
        _attack = attack;
        _move = move;
        _scan = scan;
    }

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
        _move.MoveTarget(target.transform.position,distanceTarget,action,moveSpeed);
    }

    public void EndMove()
    {
        _move.Stop();
    }

    public void AttackTarget(Entity target,float distanceAttack,float damage,Action<Entity> endAttack)
    {
        _attack.Attack(target,distanceAttack,damage,endAttack);
    }

    public void StopAttack()
    {
        _attack.StopAttack();
    }
}
