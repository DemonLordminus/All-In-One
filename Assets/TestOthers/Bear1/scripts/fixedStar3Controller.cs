using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fixedStar3Controller : Star
{
    public Transform origPos;
    public float Radius;
    private float TotalTime = 0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        spin();
    }


    [Header("圆周速度调控")]
    public float w;
    void spin()
    {

        //时间递加
        TotalTime += Time.deltaTime * w;
        //用x y 写圆周
        var x = Radius * Mathf.Cos(-5*Mathf.PI / 6 + TotalTime);
        var y = Radius * Mathf.Sin(-5*Mathf.PI / 6 + TotalTime);
        //位置移动
        transform.position = new Vector3(x, y, 0);

    }

}
