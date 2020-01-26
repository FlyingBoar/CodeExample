using UnityEngine;

public class PoolObjectBase : MonoBehaviour, IPoollable
{
    public string ID { get; private set; }
    public bool IsAvaiable { get; set; }
    public GameObject Prefab { get; set; }

    public void Setup(string _id)
    {
        ID = _id;
    }

    /// <summary>
    /// Setta lo stato del gameobject
    /// </summary>
    /// <param name="_setActive">True per attivare il gameobject, False per disattivarlo</param>
    public void ToggleObject(bool _setActive)
    {
        gameObject.SetActive(_setActive);
    }

    /// <summary>
    /// Funzione chiamata dal pooler quando l'oggetto viene reinserito nello stesso
    /// </summary>
    /// <param name="_objectState">Lo stato che deve avere il gameobject</param>
    /// <param name="_parent">Viene settato il parent e la posizione c</param>
    public virtual void RetrieveObject(bool _objectState, Transform _parent = null)
    {
        if (_parent != null)
        {
            gameObject.transform.parent = _parent;
            gameObject.transform.position = _parent.position;
        }
        gameObject.SetActive(_objectState);
    }
}
