using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obj1 : PoolObjectBase
{
    public void SetPosition(Vector3 _pos)
    {
        transform.position = _pos;
    }
}
