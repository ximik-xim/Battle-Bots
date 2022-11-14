using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class SpawnFabric<K> : MonoBehaviour where K : Enum
{
    public abstract void Spawn(K type, int count, Vector3 position);
}
