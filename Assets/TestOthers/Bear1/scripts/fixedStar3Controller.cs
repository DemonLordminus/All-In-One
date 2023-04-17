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


    [Header("Բ���ٶȵ���")]
    public float w;
    void spin()
    {

        //ʱ��ݼ�
        TotalTime += Time.deltaTime * w;
        //��x y дԲ��
        var x = Radius * Mathf.Cos(-5*Mathf.PI / 6 + TotalTime);
        var y = Radius * Mathf.Sin(-5*Mathf.PI / 6 + TotalTime);
        //λ���ƶ�
        transform.position = new Vector3(x, y, 0);

    }

}
