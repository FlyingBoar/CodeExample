using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public List<PoolStruct> ObjectsToPool = new List<PoolStruct>();

    List<Pooler<PoolObjectBase>> poolers = new List<Pooler<PoolObjectBase>>();

    /// <summary>
    /// Start come entry point, il setup negli script originali era chiamato da una state machine
    /// </summary>
    private void Start()
    {
        Setup();
    }

    #region API

    /// <summary>
    /// Setup del manager creando i pooler
    /// </summary>
    public void Setup()
    {
        CreatePools();
    }

    public void Unsetup()
    {
        foreach (Pooler<PoolObjectBase> pool in poolers)
            pool.Unsetup();
    }

    /// <summary>
    /// Fra tutti i pooler cerca quello che corrisponde al tipo e gli chiede il primo oggetto disponibile
    /// </summary>
    /// <typeparam name="T">Il tipo di PoolObject richiesto</typeparam>
    /// <returns>Restituisce un IPoollable che può essere castato con il valore passato al posto del tipo T</returns>
    public T GetFirstAvaiableObject<T>() where T : PoolObjectBase
    {
        Pooler<PoolObjectBase> pool = GetPooler<T>();
        return (T)pool.GetFirstCollectable();
    }

    /// <summary>
    /// Restituisce il primo oggetto disponibile del tipo indicato, settandogli il nuovo parent
    /// </summary>
    /// <typeparam name="T">Il tipo di elemento richiesto</typeparam>
    /// <param name="_parent">Il parent che deve avere l'oggetto</param>
    /// <returns></returns>
    public T GetFirstAvaiableObject<T>(Transform _parent) where T : PoolObjectBase
    {
        T obj = GetFirstAvaiableObject<T>();
        obj.GetComponent<Transform>().SetParent(_parent);
        return obj;
    }

    /// <summary>
    /// Ritorna l'oggetto poollato al pooler corrispondente
    /// </summary>
    /// <typeparam name="T">Il tipo dell'oggetto che viene restituito</typeparam>
    /// <param name="_poollable">L'oggetto da restituire al pooler</param>
    public void RetrievePoollable<T>(T _poollable) where T : IPoollable
    {
        GetPooler<T>().RetrieveCollectable(_poollable);
    }

    /// <summary>
    /// Ritorna tutti gli elementi poollabili del tipo specificato
    /// </summary>
    /// <typeparam name="T">un pool object base</typeparam>
    /// <returns></returns>
    public List<T> GetAllElements<T>()
    {
        Pooler<PoolObjectBase> pool = GetPooler<T>();
        return pool.GetAllElements<T>();
    }

    #endregion

    /// <summary>
    /// Per ogni oggetto che deve essere poollato crea un gameobject figlio ed un pooler
    /// </summary>
    void CreatePools()
    {
        foreach (PoolStruct pooled in ObjectsToPool)
        {
            GameObject g = new GameObject("Pool_" + pooled.ID);
            g.transform.parent = transform;
            g.transform.position = transform.position;
            Pooler<PoolObjectBase> pool = new Pooler<PoolObjectBase>(pooled, g.transform);
            poolers.Add(pool);
        }
    }

    /// <summary>
    /// Cerca il pooler che si occupa di un determinato tipo di oggetto poollable
    /// </summary>
    /// <typeparam name="T">Il tipo di oggetto di cui si occupa il pooler</typeparam>
    /// <returns>Il pooler che si occupa dell'oggetto passato</returns>
    Pooler<PoolObjectBase> GetPooler<T>()
    {
        Pooler<PoolObjectBase> pool = null;

        foreach (var item in poolers)
        {
            if (item.GetPoolObjType() == typeof(T))
            {
                pool = item;
                break;
            }
        }
        return pool;
    }

    [System.Serializable]
    public struct PoolStruct
    {
        public string ID;
        public PoolObjectBase Prefab;
        public int Quantity;
        public bool ObjectStateOnRetrieve;
    }
}
