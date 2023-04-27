using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ErLiHeJiMiHeng : Enemy2
{
    public Transform player;//玩家位置
    public Transform transOwn;//自身位置
    public Transform pursue;//追踪位置

    public AIDestinationSetter pursuePoint;//追击点
    public Rigidbody2D rb;

    public float speed = 6f;
    public float speedRate = 1f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        ForceChaseTarget();
        //if (Mathf.Sqrt(Mathf.Pow((player.position.x - transOwn.position.x), 2) + Mathf.Pow((player.position.y - transOwn.position.y), 2)) < 30f)
        //{
        //    speed = 2f;
        //}
        //else
        //{
        //    speed = 6f;
        //}
        if(Vector2.Distance(player.position, transOwn.position) < 6f)
        {
            if(speedRate > 0.5f)
            {
                speedRate -= 0.001f;
            }
        }
        else
        {
            speedRate = 1f;
        }
        ChangeSpeed(speed * speedRate);
        ////计算追踪位置
        //if (pursue != null) //目前不确定pursue的使用方法，我先暂时添加非空判断避免报错
        //{
        //    pursue.position = new Vector2(player.position.x + (player.position.x - transOwn.position.x) + rb.velocity.x,
        //    player.position.y + (player.position.y - transOwn.position.y) + rb.velocity.y);
        //}
        //if (player.position.x > transOwn.position.x)//改变方向
        //{
        //    transOwn.localScale = new Vector3(1f, 1f, 1f);
        //}
        //else
        //{
        //    transOwn.localScale = new Vector3(-1f, 1f, 1f);
        //}
        //pursuePoint.target = pursue;
    }
    [EditorButton]//是我自己的工具，不能用删了就行
    public void ChangeSpeed(float speed)
    {
        var path = gameObject.GetComponent<AIPath>();
        path.maxSpeed = speed;
    }

    public Transform forceTarget;
    public void ForceChaseTarget()//加入update食用
    {
        if (forceTarget != null)
        {
            pursuePoint.target = forceTarget;
        }
    }
}

