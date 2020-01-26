using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obj2 : PoolObjectBase
{
    public void SetPosition(Vector3 _pos)
    {
        transform.position = new Vector3(_pos.x, _pos.y + 2, _pos.z);
    }
}
