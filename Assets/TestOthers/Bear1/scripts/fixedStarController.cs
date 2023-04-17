using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class fixedStarController : Star
{
    public Vector3 OrigPos;
    public float Radius;
    private float TotalTime = 0f;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //调用方法圆周运动
        spin();
    }
    //圆周运动
    //设置一个角速度标量用于调节速度
    [Header("圆周速度调控")]
    public float w;
    void spin()
    {

        //时间递加
        TotalTime += Time.deltaTime * w;
        //用x y 写圆周
        var x = Radius * Mathf.Cos(-Mathf.PI / 6 + TotalTime);
        var y = Radius * Mathf.Sin(-Mathf.PI / 6 + TotalTime);
        //位置移动
        transform.position = new Vector3(x, y, 0);

    }



}







