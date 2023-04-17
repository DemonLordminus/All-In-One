using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    //�޵�ʱ����
    public float timenvincible = 2.0f;
    //�ж��Ƿ��޵б���
    bool islnvincible;
    //����һ���޵м�ʱ��
    float invincibleTimer;
    public float Speed;
    public Vector3 PlayerInput;
    //make the life number
    public int MaxHealth = 5;
    
    public int currentHealth;
    //�����������
    Rigidbody2D rigidbody2D;
    //�����������
    Animator animator;
    //�����λ���������洢Ruby��ֹ������ʱ��ķ���
    //��ȡ��ֹ�����ĳ���
    //�Լ�����һ��
    Vector2 lookDirection = new Vector2(1,0);
    Vector2 move;

   
    // Start is called before the first frame update
     private void Start()
    {//��õ�ǰ��Ϸ����ø������
        rigidbody2D = GetComponent<Rigidbody2D>();
        currentHealth = MaxHealth;
        //�õ�һ����������
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        //�����ƶ�����
        PlayerInput = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        move = PlayerInput * Speed * Time.deltaTime;
        lookDirection = move;
        rigidbody2D.position =(Vector3)move + transform.position;
        ChangeHealth(1);
        if (islnvincible)
        {
          
            //����޵н��� ����ʱ
            invincibleTimer -= Time.deltaTime;
            if(invincibleTimer < 0) {
                //�޵�ʱ����� ����Ϊ
                islnvincible = false;

            }
        }
        //ֹͣ�˶���ʱ�򣬵ĳ���
        if (!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
        {


            lookDirection.Normalize();
        }
        //����Ruby��blend tree
        animator.SetFloat("Look X", lookDirection.x);
        animator.SetFloat("Look Y",lookDirection.y);
        animator.SetFloat("Speed", move.magnitude);






    }












    //����ϵͳ
    public void ChangeHealth(int amount)
    {
        //��������ܵ��˺���ʱ����������2��
        if( amount<0) {
            //�ж��Ƿ��޵�
            if (islnvincible)
            {
                //�޵в���Ѫ
                return;

            }
            //�������޵�״̬ʱ��ִ�д���
            islnvincible = true;
            invincibleTimer = timenvincible;
            //����
            animator.SetTrigger("Hit");
        }

       

        //��������ֵΪ0-���ֵ
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, MaxHealth);
        //���
        Debug.Log("��ǰ����ֵ��" + currentHealth + "/" + MaxHealth);
    }


}
