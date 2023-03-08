using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Singleton<T>
{
    //�ⲿ���ɷ���
    private static T instance;

    //�ⲿ�ɷ��ʣ��в��ɸ���
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
