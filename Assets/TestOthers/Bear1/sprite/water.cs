using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class water : MonoBehaviour
{
    public static int count = 0;
    //声明刚体
    Rigidbody2D rigidbody2D;
    public float seconds = 5f;

    private void Start()
    {
        count++;
        Invoke("AutoDestroySelf", seconds);
       //调用刚体
       rigidbody2D = GetComponent<Rigidbody2D>();
     }
    //发射子弹
    public void ChangeForce(Vector2 direction,float force)
    {
        //施加一个力使之移动
        rigidbody2D.AddForce(direction * force);
    }
    private void Update()
    {
        transform.eulerAngles += LookAt2DTool.LookTo2DWithDirectionAddRotation(transform,rigidbody2D.velocity,90);
    }
    void AutoDestroySelf()
    {
        Debug.Log("销毁water",gameObject);
        Destroy(gameObject);
    }
    private void OnDestroy()
    {
        count--;
    }
    //碰撞事件方法
    private void OnCollisionEnter2D(Collision2D collision)
    {
        




    }





}