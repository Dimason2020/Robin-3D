using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    static T _instance;

    public static T Instance
    {
        get
        {
            if (!_instance)
                _instance = FindObjectOfType<T>();

            return _instance;
        }
    }

    public virtual void Awake()
    {
        _instance = this as T;
    }
}