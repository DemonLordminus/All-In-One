using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    //public Transform origPos;
    public float Radius;
    private float TotalTime = 0f;

    [Header("圆周速度调控")]
    public float w;
    public float stratPostion;
    void spin()
    {
        //时间递加
        TotalTime += Time.deltaTime * w;
        //用x y 写圆周
        var x = Radius * Mathf.Cos(stratPostion * Mathf.PI + TotalTime);
        var y = Radius * Mathf.Sin(stratPostion * Mathf.PI + TotalTime);
        //位置移动
        transform.position = new Vector3(x, y, 0);
    }

    void Update()
    {
        spin();
    }
}
