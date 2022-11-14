using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractScan : MonoBehaviour
{
 public abstract void Scan(float range, Action<Entity> detectEntity);
 public abstract void EndScan();
}
