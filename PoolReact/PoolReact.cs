using System;
using UnityEngine;

public abstract class PoolReact : MonoBehaviour
{
  private event Action<bool, MonoBehaviour> _enable;
 
  public void AddPool(Action<bool,MonoBehaviour> action)
  {
    _enable += action;
  }
  
  private void OnEnable()
  {
    Enable();
    _enable?.Invoke(true,this);
  }

  protected virtual void Enable()
  {
    
  }

  private void OnDisable()
  {
    Disable();
    _enable?.Invoke(false, this);
  }
  
  protected virtual void Disable()
  {
    
  }
}
