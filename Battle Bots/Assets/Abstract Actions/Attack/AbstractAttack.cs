using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractAttack : MonoBehaviour
{
    public abstract void Attack(Entity target, float distanceAttack, float damage, Action<Entity> endAttack);
    public abstract void StopAttack();
}
