using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class water : MonoBehaviour
{
    public static int count = 0;
    //��������
    Rigidbody2D rigidbody2D;
    public float seconds = 5f;

    private void Start()
    {
        count++;
        Invoke("AutoDestroySelf", seconds);
       //���ø���
       rigidbody2D = GetComponent<Rigidbody2D>();
     }
    //�����ӵ�
    public void ChangeForce(Vector2 direction,float force)
    {
        //ʩ��һ����ʹ֮�ƶ�
        rigidbody2D.AddForce(direction * force);
    }
    private void Update()
    {
        transform.eulerAngles += LookAt2DTool.LookTo2DWithDirectionAddRotation(transform,rigidbody2D.velocity,90);
    }
    void AutoDestroySelf()
    {
        Debug.Log("����water",gameObject);
        Destroy(gameObject);
    }
    private void OnDestroy()
    {
        count--;
    }
    //��ײ�¼�����
    private void OnCollisionEnter2D(Collision2D collision)
    {
        




    }





}