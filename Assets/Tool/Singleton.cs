using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Singleton<T>
{
    //外部不可访问
    private static T instance;

    //外部可访问，切不可更改
    public static T Instance
    {
        get { return instance; }
    }
    protected virtual void Awake()
    {
        if (instance != null)
            Destroy(gameObject);
        else
        {
            instance = (T)this;
        }
    }
    public static bool IsInitiailzed
    {
        get { return instance != null; }
    }
    protected virtual void OnDestory()
    {
        if(instance == this)
        {
            instance = null;
        }
    }
}
