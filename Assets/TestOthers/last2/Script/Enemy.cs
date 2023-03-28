using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyLast : MonoBehaviour
{
    public int i = 0;
   [SerializeField]public static List<GameObject> money;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Pacman")
        {
            if(Praise.isStrong)
            {
                Destroy(gameObject);
            }
            else
            {
                Player.money /= 2;
                moneyGenerate();
            }
        }
    }

    //public AIDestinationSetter wanderPoint;
    //public Transform wanderPiont;

    //public void wander()//闲逛，还未实现
    //{

    //    wanderPoint.target = wanderPiont;
    //    return;
    //}

    //金币生成函数
    public void moneyGenerate()
    {
        i = Random.Range(0, 5);
        while (true)
        {
            if (money[i] == null)
            {
                i = Random.Range(0, 5);
                continue;
            }
            else
            {
                break;
            }
        }
        money[i].SetActive(true);
    }
}
