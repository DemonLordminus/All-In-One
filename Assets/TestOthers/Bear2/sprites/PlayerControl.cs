using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    //无敌时间间隔
    public float timenvincible = 2.0f;
    //判断是否无敌变量
    bool islnvincible;
    //定义一个无敌计时器
    float invincibleTimer;
    public float Speed;
    public Vector3 PlayerInput;
    //make the life number
    public int MaxHealth = 5;
    
    public int currentHealth;
    //声明刚体对象
    Rigidbody2D rigidbody2D;
    //声明动画组件
    Animator animator;
    //创造二位对象，用来存储Ruby静止不动的时候的方向
    //获取静止不动的朝向
    //自己设置一个
    Vector2 lookDirection = new Vector2(1,0);
    Vector2 move;

   
    // Start is called before the first frame update
     private void Start()
    {//获得当前游戏对象得刚体组件
        rigidbody2D = GetComponent<Rigidbody2D>();
        currentHealth = MaxHealth;
        //得到一个动画对象
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        //人物移动代码
        PlayerInput = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        move = PlayerInput * Speed * Time.deltaTime;
        lookDirection = move;
        rigidbody2D.position =(Vector3)move + transform.position;
        ChangeHealth(1);
        if (islnvincible)
        {
          
            //如果无敌进入 倒计时
            invincibleTimer -= Time.deltaTime;
            if(invincibleTimer < 0) {
                //无敌时间等于 无作为
                islnvincible = false;

            }
        }
        //停止运动的时候，的朝向
        if (!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
        {


            lookDirection.Normalize();
        }
        //传递Ruby给blend tree
        animator.SetFloat("Look X", lookDirection.x);
        animator.SetFloat("Look Y",lookDirection.y);
        animator.SetFloat("Speed", move.magnitude);






    }












    //生命系统
    public void ChangeHealth(int amount)
    {
        //假设玩家受到伤害的时间间隔，必须2秒
        if( amount<0) {
            //判断是否无敌
            if (islnvincible)
            {
                //无敌不伤血
                return;

            }
            //当不是无敌状态时，执行代码
            islnvincible = true;
            invincibleTimer = timenvincible;
            //受伤
            animator.SetTrigger("Hit");
        }

       

        //限制生命值为0-最大值
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, MaxHealth);
        //输出
        Debug.Log("当前生命值：" + currentHealth + "/" + MaxHealth);
    }


}
