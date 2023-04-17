using UnityEngine;

public class enemyController : MonoBehaviour
{


    public float speed;
    //��ֱ�ƶ���true y�� false��x���ƶ�
    public bool vertical;

    Rigidbody2D rigidbody2d;
    //һ���������ʱ��
    public float changTime = 3.0f;
    //��ʱ��
    float timer;
    int direction = 1;
    Animator animator;

    void Start()
    {
        //��ȡһЩ����ֵ

        rigidbody2d = GetComponent<Rigidbody2D>();
        timer = changTime;
        animator=GetComponent<Animator>();


    }
    void Update()
    {
        //ÿ�μ���һ��
        timer -= Time.deltaTime;
        //timerС��0����
        if (timer < 0)
        {
            direction = -direction;
            timer = changTime;
        }
    }
    private void FixedUpdate()
    {
        //��õ�ǰ���������λ��
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
    //������ײ�¼�
    private void OnCollisionEnter2D(Collision2D other )
    {          //��ȡ��Ҷ���
               PlayerControl rubyController =other.gameObject.GetComponent<PlayerControl>();
        if ( rubyController != null )
        {
            rubyController.ChangeHealth(-1);
        }

    }








}