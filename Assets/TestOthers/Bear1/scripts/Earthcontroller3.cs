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
        //���÷���Բ���˶�
        spin();
    }
    //Բ���˶�
    //����һ�����ٶȱ������ڵ����ٶ�
    [Header("Բ���ٶȵ���")]
    public float w;
    [Header("Բ��λ�õ���")]
    public float stratPostion;
    void spin()
    {

        //ʱ��ݼ�
        TotalTime += Time.deltaTime * w;
        //��x y дԲ��
        var x = Radius * Mathf.Cos(Mathf.PI * stratPostion + TotalTime);
        var y = Radius * Mathf.Sin(Mathf.PI * stratPostion + TotalTime);
        //λ���ƶ�
       this.transform.position =OrigPo.position+ new Vector3(x, y, 0);

    }



}