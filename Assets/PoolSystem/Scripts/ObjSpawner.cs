using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjSpawner : MonoBehaviour
{
    PoolManager manager;

    public void Setup(PoolManager _poolManager)
    {
        manager = _poolManager;
    }

    /// <summary>
    /// Spawna un Obj1 sulla posizione dello spawner
    /// </summary>
    public void SpawnObj1()
    {
        Obj1 obj = (manager.GetFirstAvaiableObject<Obj1>() as Obj1);
        obj.SetPosition(transform.position);
    }
    /// <summary>
    /// Spawna un Obj2 sulla posizione dello spawner
    /// </summary>
    public void SpawnObj2()
    {
        Obj2 obj = (manager.GetFirstAvaiableObject<Obj2>() as Obj2);
        obj.SetPosition(transform.position);
    }
    /// <summary>
    /// Resetta gli oggetti
    /// </summary>
    public void RestObjects()
    {
        manager.Unsetup();
    }
}
