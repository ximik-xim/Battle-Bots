using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public abstract class EntityFabric<K,T> : DicteneryElementFabric<K,T> where T : Entity where K : Enum
{

}
