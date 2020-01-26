using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_GameplayPanel : UI_MenuBase
{
    public void SpawnObj1()
    {
        GameManager.I.GetObjSpawner().SpawnObj1();
    }

    public void SpawnObj2()
    {
        GameManager.I.GetObjSpawner().SpawnObj2();
    }

    public void ResetObjects()
    {
        GameManager.I.GetObjSpawner().RestObjects();
    }
}
