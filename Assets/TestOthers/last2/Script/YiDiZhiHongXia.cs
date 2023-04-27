using Microsoft.Cci;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class YiDiZhiHongXia : Enemy2
{
    //public LayerMask Obstacle;
    public Transform player;
    public Transform transOwn;
    public Transform targetPos;//追击位置

    public float speed = 3f;
    public float distance = 5f;

    private void Start()
    {
        //计算玩家与自身的距离
    //    distance = Mathf.Sqrt(Mathf.Pow((player.position.x - transOwn.position.x), 2) + Mathf.Pow((player.position.y - transOwn.position.y), 2));
    }

    private void Update()
    {
        //计算追踪位置
        //targetPos.position = new Vector2(player.position.x - (player.position.y - transOwn.position.y) * (5f / distance),
        //    player.position.y + (player.position.x - transOwn.position.x) * (5f / distance));
        //判断玩家是否强化
        if (!Praise.isStrong)
        {
            if (player.position.x > transOwn.position.x)//改变方向
            {
                transOwn.localScale = new Vector3(1f, 1f, 1f);
            }
            else
            {
                transOwn.localScale = new Vector3(-1f, 1f, 1f);
            }
            gameObject.transform.position = Vector2.MoveTowards(transform.position, targetPos.position, speed * Time.deltaTime);
        }
        else
        {
            if (player.position.x > transOwn.position.x)
            {
                transOwn.localScale = new Vector3(-1f, 1f, 1f);
            }
            else
            {
                transOwn.localScale = new Vector3(1f, 1f, 1f);
            }
            gameObject.transform.position = Vector2.MoveTowards(transform.position, targetPos.position, -speed * Time.deltaTime);
        }
    }
}
