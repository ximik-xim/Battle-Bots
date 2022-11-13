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
    
    private Action<bool> _endAttack;
    private bool _isActive = false;
    private CancellationTokenSource _token = new CancellationTokenSource();
    private void OnEnable()
    {
        _isActive = false;
    }

    public override void Attack(Entity target, float distanceAttack, float damage, Action<bool> endAttack,Action killEntity)
    {
        _endAttack = endAttack;
        TimeAttack(() => TakeDamage(target, distanceAttack, damage,killEntity), _token.Token);
    }


    private void TakeDamage(Entity target, float distanceAttack, float damage,Action killEntity)
    {
        if (Vector3.Distance(transform.position, target.transform.position) <= distanceAttack)
        {
            target.TakeDamage(damage, killEntity);
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
     
        if (_isActive == false)
        {
            action?.Invoke();    
        }
    }

    private void OnDisable()
    {
        _token.Cancel();
        _isActive = true;
    }
}
