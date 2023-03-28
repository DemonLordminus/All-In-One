using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public static bool isLowSpeed = false;//�ж�����Ƿ񱻼���
    public float speed = 0.3f;
    private Vector2 dest = Vector2.zero;//�Զ�����һ��Ҫȥ��Ŀ�ĵ�

    public static int money = 0;//Ǯ������
    public Text moneyNum;

    public static int Hp = 1000;//���Ѫ��
    public Text HpNum;

    void Start()
    {
        dest = transform.position;//��֤��Ҹտ�ʼ��ʱ�򲻻ᶯ
    }

    void Update()
    {
        //����ƶ�
        Vector2 temp = Vector2.MoveTowards(transform.position, dest, speed);//��ֵ�õ�Ҫ�ƶ���destλ�õ���һ���ƶ�����
        GetComponent<Rigidbody2D>().MovePosition(temp);//ͨ�����������������λ��
        //�����ȴﵽ��һ��dest��λ�ò��ܷ�����һ��Ŀ�ĵص�����ָ��
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
        //��ȡ�ƶ�����
        Vector2 dir = dest - (Vector2)transform.position;
        //�ѻ�ȡ�����ƶ��������ø�����״̬��
        //GetComponent<Animator>().SetFloat("DirX", dir.x);
        //GetComponent<Animator>().SetFloat("DirY", dir.y);
        //��ʱû�����ö��������ͱ�������ˣ�ע�͵�����

        moneyNum.text = money.ToString();//��ʾ����ռ�����

        Fire();//��ҹ����ܵ��˺�
        HpNum.text = Hp.ToString();//��ʾ���Ѫ��
        Death(Hp);

        if(Light.IsLowSpeed)//��Ҽ���
        {
            lowSpeed();
        }
        if(Light.IsExit)//��һָ��ٶ�
        {
            speed /= 0.8f;
            Light.IsExit = false;
        }
    }

    //���Ҫȥ�ĵط��ܷ�ﵽ
    private bool Valid(Vector2 dir)
    {
        //��¼��ǰλ��
        Vector2 pos = transform.position;
        //�ӽ�Ҫ�����λ����ǰλ�÷���һ�����ߣ���������������Ϣ
        RaycastHit2D hit = Physics2D.Linecast(pos + dir, pos);
        //���ش������Ƿ�ﵽ��
        return (hit.collider == GetComponent<Collider2D>() || hit.collider.isTrigger);
    }

    //����������ڹ����»��𽥵�Ѫ������
    public void Fire()
    {
        if(Light.IsFire)
        {
            Hp--;
        }
    }

    //�ж�����Ƿ�����
    public void Death(int Hp)
    {
        if (Hp <= 0)
        {
            Destroy(gameObject);
        }
    }

    //ʹ��Ҽ���
    public void lowSpeed()
    {
        speed *= 0.8f;
        Light.IsLowSpeed = false;
    }
}
