using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    //简化的单例写法
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

    public int goldCount;//玩家金币数量
    public void GetGold(int _goldCount)
    {
        goldCount += _goldCount;
        Debug.Log("玩家金币增加");
    }
}
