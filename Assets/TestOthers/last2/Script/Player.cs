using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float speed = 0.3f;
    private Vector2 dest = Vector2.zero;

    public static int money = 0;
    public Text moneyNum;

    public int Hp = 10000;
    public Text HpNum;
    // Start is called before the first frame update
    void Start()
    {
        dest = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 temp = Vector2.MoveTowards(transform.position, dest, speed);
        GetComponent<Rigidbody2D>().MovePosition(temp);
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
        Vector2 dir = dest - (Vector2)transform.position;
        //GetComponent<Animator>().SetFloat("DirX", dir.x);
        //GetComponent<Animator>().SetFloat("DirY", dir.y);

        Fire();
        moneyNum.text = money.ToString();
        HpNum.text = Hp.ToString();
    }

    private bool Valid(Vector2 dir)
    {
        Vector2 pos = transform.position;
        RaycastHit2D hit = Physics2D.Linecast(pos + dir, pos);
        return (hit.collider==GetComponent<Collider2D>() || hit.collider.isTrigger);

    }

    public void Fire()
    {
        if(Light.IsFire)
        {
            Hp--;
        }
    }
}
