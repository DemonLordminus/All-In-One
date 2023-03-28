using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Escape : MonoBehaviour
{
    public AIDestinationSetter escapePoint;
    public Transform transOwn;//记录敌人自身位置
    public Transform transRightUp, transRightDown, transLeftUp, transLeftDown;//记录地图边角四个点的位置
    public Transform player;//记录玩家位置

    private void Start()
    {
        escapePoint = GetComponent<AIDestinationSetter>();
        transOwn = GetComponent<Transform>();
    }

    private void Update()
    {
        escape();
    }

    //当玩家强化时，敌人会向地图边角逃离
    public void escape()
    {
        if (Praise.isStrong)
        {
            if (transOwn.position.x < player.transform.position.x &&
                   transOwn.position.y < player.transform.position.y)
            {
                escapePoint.target = transLeftDown;//向左下角逃离
            }
            else if (transOwn.position.x < player.transform.position.x &&
                    transOwn.position.y >= player.transform.position.y)
            {
                escapePoint.target = transLeftUp;//向左上角逃离
            }
            else if (transOwn.position.x >= player.transform.position.x &&
                    transOwn.position.y < player.transform.position.y)
            {
                escapePoint.target = transRightDown;//向右下角逃离
            }
            else if (transOwn.position.x >= player.transform.position.x &&
                    transOwn.position.y >= player.transform.position.y)
            {
                escapePoint.target = transRightUp;//向右上角逃离
            }
            else//排除特殊情况
            {
                //当发生特殊情况时，敌人随机向地图上四个点移动
                int r = Random.Range(0, 4);
                if (r == 0)
                {
                    escapePoint.target = transRightUp;
                }
                else if (r == 1)
                {
                    escapePoint.target = transRightDown;
                }
                else if (r == 2)
                {
                    escapePoint.target = transLeftUp;
                }
                else
                {
                    escapePoint.target = transLeftDown;
                }
            }
        }
        Invoke("beWeak", 10f);
    }

    //玩家失去强化状态
    public void beWeak()
    {
        Praise.isStrong = false;
        escapePoint.target = player;
    }
}

