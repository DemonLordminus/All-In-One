using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class neutronStar : Star
{
    ////��ת����
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


    //[Header("Բ���ٶȵ���")]
    //public float w;
    //public float stratPostion;
    //void spin()
    //{
    //    //ʱ��ݼ�
    //    TotalTime += Time.deltaTime * w;
    //    //��x y дԲ��
    //    var x = Radius * Mathf.Cos(stratPostion*Mathf.PI  + TotalTime);
    //    var y = Radius * Mathf.Sin(stratPostion* Mathf.PI  + TotalTime);
    //    //λ���ƶ�
    //    transform.position = new Vector3(x, y, 0);
    //}

    //��ת
    public float spinSelfSpeed;
    void SpinSelf()
    {
        transform.Rotate(new Vector3(0, 0, spinSelfSpeed*Time.deltaTime)); //������ת
    }

    //����С����
    //�������ѡ��
    public GameObject laserLight;
    //�����ٶ�
    [Header("�����ٶ�")]
    public float laserLightSpeed;
    [SerializeField] private bool isLightLaunchAvailable;
    public Transform point1;
    public Transform point2;
    Rigidbody2D rigidbody2D;

    public float secondsAfterLaunch;
    //����ϵͳ

    void Launch()
    {
        if (isLightLaunchAvailable)
        {
            ////Debug.Log(transform.rotation);
            ////���ɼ���λ��
            //GameObject projectilePrefab1 = Instantiate(laserLight, point1.position, transform.rotation);
            //GameObject projectilePrefab2 = Instantiate(laserLight, point2.position, transform.rotation);
            ////��ø����ļ�
            //Rigidbody2D waterRb1 = projectilePrefab1.GetComponent<Rigidbody2D>();
            //Rigidbody2D waterRb2 = projectilePrefab2.GetComponent<Rigidbody2D>();
            ////�ٶ�
            //waterRb1.velocity = laserLightSpeed * (point1.transform.position - transform.position);
            //waterRb2.velocity = laserLightSpeed * (point2.transform.position - transform.position);
            LaserCreate(point1);
            LaserCreate(point2);
            //�ж�
            isLightLaunchAvailable = false;
         }
    }

    IEnumerator LaserCanLuanch()
    {
        Debug.Log("Э�̴���",gameObject);
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




