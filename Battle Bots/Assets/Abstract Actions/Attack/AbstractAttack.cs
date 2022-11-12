using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public abstract class AbstractAttack : MonoBehaviour
{
    public abstract void Attack(Entity target, float distanceAttack, float damage, Action<bool> endAttack);
    public abstract void StopAttack();

    
}
