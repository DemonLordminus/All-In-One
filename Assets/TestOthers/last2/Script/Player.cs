using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public static bool isLowSpeed = false;//判断玩家是否被减速
    public float speed = 0.3f;
    private Vector2 dest = Vector2.zero;//吃豆人下一次要去的目的地

    public static int money = 0;//钱的数量
    public Text moneyNum;

    public static int Hp = 1000;//玩家血量
    public Text HpNum;

    void Start()
    {
        dest = transform.position;//保证玩家刚开始的时候不会动
    }

    void Update()
    {
        //玩家移动
        Vector2 temp = Vector2.MoveTowards(transform.position, dest, speed);//插值得到要移动到dest位置的下一次移动坐标
        GetComponent<Rigidbody2D>().MovePosition(temp);//通过刚体来设置物体的位置
        //必须先达到上一个dest的位置才能发出下一个目的地的设置指令
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W) && Valid(Vector2.up))
        {
            dest = (Vector2)transform.position + Vector2.up;
        }
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S) && Valid(Vector2.down))
        {
            dest = (Vector2)transform.position + Vector2.down;
        }
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A) && Valid(Vector2.left))
        {
            dest = (Vector2)transform.position + Vector2.left;
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D) && Valid(Vector2.right))
        {
            dest = (Vector2)transform.position + Vector2.right;
        }
        //获取移动方向
        Vector2 dir = dest - (Vector2)transform.position;
        //把获取到的移动方向设置给动画状态机
        //GetComponent<Animator>().SetFloat("DirX", dir.x);
        //GetComponent<Animator>().SetFloat("DirY", dir.y);
        //暂时没有设置动画机，就别管这里了，注释掉就行

        moneyNum.text = money.ToString();//显示金币收集数量

        Fire();//玩家光照受到伤害
        HpNum.text = Hp.ToString();//显示玩家血量
        Death(Hp);

        if(Light.IsLowSpeed)//玩家减速
        {
            lowSpeed();
        }
        if(Light.IsExit)//玩家恢复速度
        {
            speed /= 0.8f;
            Light.IsExit = false;
        }
    }

    //检测要去的地方能否达到
    private bool Valid(Vector2 dir)
    {
        //记录当前位置
        Vector2 pos = transform.position;
        //从将要到达的位置向当前位置发射一条射线，并储存下射线信息
        RaycastHit2D hit = Physics2D.Linecast(pos + dir, pos);
        //返回此射线是否达到了
        return (hit.collider == GetComponent<Collider2D>() || hit.collider.isTrigger);
    }

    //玩家如果如果在光照下会逐渐掉血并减速
    public void Fire()
    {
        if(Light.IsFire)
        {
            Hp--;
        }
    }

    //判断玩家是否死亡
    public void Death(int Hp)
    {
        if (Hp <= 0)
        {
            Destroy(gameObject);
        }
    }

    //使玩家减速
    public void lowSpeed()
    {
        speed *= 0.8f;
        Light.IsLowSpeed = false;
    }
}
