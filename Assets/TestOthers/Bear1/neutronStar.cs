using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class neutronStar : Star
{
    ////公转数据
    //public Transform origPos;
    //public float Radius;
    //private float TotalTime = 0f;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        StartCoroutine(LaserCanLuanch());
    }

    // Update is called once per frame
    void Update()
    {
        //spin();
        SpinSelf();
        Launch();
    }


    //[Header("圆周速度调控")]
    //public float w;
    //public float stratPostion;
    //void spin()
    //{
    //    //时间递加
    //    TotalTime += Time.deltaTime * w;
    //    //用x y 写圆周
    //    var x = Radius * Mathf.Cos(stratPostion*Mathf.PI  + TotalTime);
    //    var y = Radius * Mathf.Sin(stratPostion* Mathf.PI  + TotalTime);
    //    //位置移动
    //    transform.position = new Vector3(x, y, 0);
    //}

    //自转
    public float spinSelfSpeed;
    void SpinSelf()
    {
        transform.Rotate(new Vector3(0, 0, spinSelfSpeed*Time.deltaTime)); //左右旋转
    }

    //发射小激光
    //激光对象选择
    public GameObject laserLight;
    //激光速度
    [Header("激光速度")]
    public float laserLightSpeed;
    [SerializeField] private bool isLightLaunchAvailable;
    public Transform point1;
    public Transform point2;
    Rigidbody2D rigidbody2D;

    public float secondsAfterLaunch;
    //发射系统

    void Launch()
    {
        if (isLightLaunchAvailable)
        {
            ////Debug.Log(transform.rotation);
            ////生成激光位置
            //GameObject projectilePrefab1 = Instantiate(laserLight, point1.position, transform.rotation);
            //GameObject projectilePrefab2 = Instantiate(laserLight, point2.position, transform.rotation);
            ////获得刚体文件
            //Rigidbody2D waterRb1 = projectilePrefab1.GetComponent<Rigidbody2D>();
            //Rigidbody2D waterRb2 = projectilePrefab2.GetComponent<Rigidbody2D>();
            ////速度
            //waterRb1.velocity = laserLightSpeed * (point1.transform.position - transform.position);
            //waterRb2.velocity = laserLightSpeed * (point2.transform.position - transform.position);
            LaserCreate(point1);
            LaserCreate(point2);
            //判断
            isLightLaunchAvailable = false;
         }
    }

    IEnumerator LaserCanLuanch()
    {
        Debug.Log("协程触发",gameObject);
        isLightLaunchAvailable = true;
        yield return new WaitForSeconds(secondsAfterLaunch);
        StartCoroutine(LaserCanLuanch());
    }

    private void LaserCreate(Transform point)
    {
        GameObject projectilePrefab1 = Instantiate(laserLight, point.position, transform.rotation);
        Rigidbody2D waterRb = projectilePrefab1.GetComponent<Rigidbody2D>();
        waterRb.velocity = laserLightSpeed * (point.transform.position - transform.position);
    }



}




