using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    /// <summary>
    /// Riferimento allo UI manager
    /// </summary>
    UIManager uiMng;
    /// <summary>
    /// Riferimento al pool manager
    /// </summary>
    PoolManager poolMng;
    /// <summary>
    /// Riferimento all'Object spawner
    /// </summary>
    ObjSpawner objSpawner;


    /// <summary>
    /// Riferimento alla State machine
    /// </summary>
    Animator SM;

    public static GameManager I;

    // Start is called before the first frame update
    void Start()
    {
        if (I == null)
            InternalSetup();
        else
            DestroyImmediate(gameObject);
    }
    /// <summary>
    /// Inizializza in singleton, prende riferimento della state machine e la fa partire
    /// </summary>
    void InternalSetup()
    {
        I = this;
        SM = GetComponent<Animator>();
        StartSM();
    }

    #region Get & Set

    // ------------------------ GET ----------------------------- \\

    /// <summary>
    /// Ritorna il riferimento allo UIManager
    /// </summary>
    /// <returns></returns>
    public UIManager GetUIManager()
    {
        return I.uiMng;
    }
    /// <summary>
    /// Ritorna il riferimento al Pool manager
    /// </summary>
    /// <returns></returns>
    public PoolManager GetPoolManager()
    {
        return I.poolMng;
    }
    /// <summary>
    /// Ritorna il riferimento all'Object spawner
    /// </summary>
    /// <returns></returns>
    public ObjSpawner GetObjSpawner()
    {
        return I.objSpawner;
    }

    //// ------------------------ SET ----------------------------- \\

    /// <summary>
    /// Setta il riferimento allo UIManager
    /// </summary>
    /// <param name="_uiManager"></param>
    public void SetUIManager(UIManager _uiManager)
    {
        I.uiMng = _uiManager;
    }
    /// <summary>
    /// Setta il riferimento al PoolMng
    /// </summary>
    /// <param name="_poolManager"></param>
    public void SetPoolManager(PoolManager _poolManager)
    {
        I.poolMng = _poolManager;
    }
    /// <summary>
    /// Setta il riferimento all'Object spawner
    /// </summary>
    /// <param name="_spawner"></param>
    public void SetObjectSpawner(ObjSpawner _spawner)
    {
        I.objSpawner = _spawner;
    }
    #endregion

    #region SM triggers
    /// <summary>
    /// Triggera la partenza della State machine
    /// </summary>
    private void StartSM()
    {
        SM.SetTrigger("StartSM");
    }
    /// <summary>
    /// Triggera il cambio di stato per andare nel Setup
    /// </summary>
    public void GoToNext()
    {
        SM.SetTrigger("GoToNext");
    }

    #endregion
}
