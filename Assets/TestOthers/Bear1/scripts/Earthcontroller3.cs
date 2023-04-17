using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Earthcontroller3 : Star
{
    public Transform OrigPo;
    public float Radius;
    private float TotalTime = 0f;

    void Start()
    {
        OrigPo=gameObject.transform.parent.transform;
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
    [Header("圆周位置调控")]
    public float stratPostion;
    void spin()
    {

        //时间递加
        TotalTime += Time.deltaTime * w;
        //用x y 写圆周
        var x = Radius * Mathf.Cos(Mathf.PI * stratPostion + TotalTime);
        var y = Radius * Mathf.Sin(Mathf.PI * stratPostion + TotalTime);
        //位置移动
       this.transform.position =OrigPo.position+ new Vector3(x, y, 0);

    }



}