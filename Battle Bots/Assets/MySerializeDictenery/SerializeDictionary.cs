using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class SerializeDictionary<K,D>:Dictionary<K,D>
{
    [SerializeField]
    private List<KeyAndData<K, D>> _listKeyAndData;

    public void Initialization()
    {
        for (int i = 0; i < _listKeyAndData.Count; i++)
        {
            this.Add(_listKeyAndData[i]._k,_listKeyAndData[i]._d);    
        }
        
        _listKeyAndData.Clear();
    }
}

[System.Serializable]
public class KeyAndData<K, D>
{
    public K _k;
    public D _d;
}