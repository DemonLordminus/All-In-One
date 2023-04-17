using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    //public Transform origPos;
    public float Radius;
    private float TotalTime = 0f;

    [Header("Բ���ٶȵ���")]
    public float w;
    public float stratPostion;
    void spin()
    {
        //ʱ��ݼ�
        TotalTime += Time.deltaTime * w;
        //��x y дԲ��
        var x = Radius * Mathf.Cos(stratPostion * Mathf.PI + TotalTime);
        var y = Radius * Mathf.Sin(stratPostion * Mathf.PI + TotalTime);
        //λ���ƶ�
        transform.position = new Vector3(x, y, 0);
    }

    void Update()
    {
        spin();
    }
}
