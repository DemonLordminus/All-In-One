using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    //�򻯵ĵ���д��
    public static PlayerManager instance;
    protected void Awake()
    {
        if (instance != null)
            Destroy(gameObject);
        else
        {
            instance = this;
        }
    }

    public int goldCount;//��ҽ������
    public void GetGold(int _goldCount)
    {
        goldCount += _goldCount;
        Debug.Log("��ҽ������");
    }
}
