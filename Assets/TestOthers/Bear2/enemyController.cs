using UnityEngine;

public class enemyController : MonoBehaviour
{


    public float speed;
    //垂直移动，true y轴 false按x抽移动
    public bool vertical;

    Rigidbody2D rigidbody2d;
    //一个对象的总时间
    public float changTime = 3.0f;
    //计时器
    float timer;
    int direction = 1;
    Animator animator;

    void Start()
    {
        //获取一些对象值

        rigidbody2d = GetComponent<Rigidbody2D>();
        timer = changTime;
        animator=GetComponent<Animator>();


    }
    void Update()
    {
        //每次减少一秒
        timer -= Time.deltaTime;
        //timer小于0重置
        if (timer < 0)
        {
            direction = -direction;
            timer = changTime;
        }
    }
    private void FixedUpdate()
    {
        //获得当前对象的所在位置
        Vector2 position = transform.position;
        if (vertical)
        {
            position.y = position.y + Time.deltaTime * speed * direction;
            animator.SetFloat("Move X", 0);
            animator.SetFloat("Move Y", direction);
        }
        else
        {
            position.x = position.x + Time.deltaTime * speed * direction;
            animator.SetFloat("Move X", direction);
            animator.SetFloat("Move Y", 0);
        }
        rigidbody2d.MovePosition(position);
    }
    //刚体碰撞事件
    private void OnCollisionEnter2D(Collision2D other )
    {          //获取玩家对象
               PlayerControl rubyController =other.gameObject.GetComponent<PlayerControl>();
        if ( rubyController != null )
        {
            rubyController.ChangeHealth(-1);
        }

    }








}