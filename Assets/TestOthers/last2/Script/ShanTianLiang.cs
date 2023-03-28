using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ShanTianLiang : Enemy
{
    public Transform transOwn;
    public Transform player;
    public AIDestinationSetter pursuePoint;//追击点
    public Transform wanderPiont;
    public Rigidbody2D rb;

    public float speed = 5f;
    public float speedRate = 1f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        transOwn = GetComponent<Transform>();
    }

    private void Update()
    {
        //如果玩家在判定范围内，开始追击玩家并随着玩家纸币数量的增多而加速
        if (isPursue() && Player.money > 0)
        {
            pursuePoint.target = player;
            IncreaseSpeed();
        }
        else
        {
            speedRate = 1f;
            pursuePoint.target = wanderPiont;
        }
        ChangeSpeed(speed * speedRate);
    }

    public bool isPursue()//山田凉的追击判定范围，不完善
    {
        if (Vector2.Distance(transOwn.position, player.position) < Player.money)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    [EditorButton]//是我自己的工具，不能用删了就行
    public void ChangeSpeed(float speed)
    {
        var lerp = gameObject.GetComponent<AILerp>();
        lerp.speed = speed;
    }

    public void IncreaseSpeed()
    {
        if (speedRate < 1.5f)
        {
            speedRate = 1f + 0.01f * Player.money;
        }
    }
}