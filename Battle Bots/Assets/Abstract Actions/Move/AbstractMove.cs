using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractMove : MonoBehaviour
{
    public abstract void Patrolling();
    public abstract void MoveTarget(Vector3 position, float distance, Action action, float moveSpeed);
    public abstract void Stop();
}
