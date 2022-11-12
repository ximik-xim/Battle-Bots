using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class TimeAttacks : AbstractAttack
{
    [SerializeField] 
    private float _speedAttack;
    private CancellationTokenSource _token = new CancellationTokenSource();
    private Action<bool> _endAttack;
    public override void Attack(Entity target, float distanceAttack, float damage, Action<bool> endAttack)
    {
        _endAttack = endAttack;
        TimeAttack(() => Test(target, distanceAttack, damage), _token.Token);
    }


    private void Test(Entity target, float distanceAttack, float damage)
    {
        if (Vector3.Distance(transform.position, target.transform.position) <= distanceAttack)
        {
            target.TakeDamage(damage);
        }
        
        
        _endAttack?.Invoke(true);
    }
    public override void StopAttack()
    {
        _token.Cancel();
        _endAttack?.Invoke(false);
    }
    
    private async Task TimeAttack(Action action,CancellationToken token)
    {
        await Task.Delay((int) (1000 * _speedAttack), token);
        action.Invoke();
    }

    private void OnDisable()
    {
        _token.Cancel();
    }
}
