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
        //���÷���Բ���˶�
        spin();
    }
    //Բ���˶�
    //����һ�����ٶȱ������ڵ����ٶ�
    [Header("Բ���ٶȵ���")]
    public float w;
    void spin()
    {

        //ʱ��ݼ�
        TotalTime += Time.deltaTime * w;
        //��x y дԲ��
        var x = Radius * Mathf.Cos(-Mathf.PI / 6 + TotalTime);
        var y = Radius * Mathf.Sin(-Mathf.PI / 6 + TotalTime);
        //λ���ƶ�
        transform.position = new Vector3(x, y, 0);

    }



}







