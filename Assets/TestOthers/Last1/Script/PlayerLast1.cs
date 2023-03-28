using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLast1 : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    private Animator anim;
    private float inputX, inputY;
    private float stopX, stopY;
    private int moveDir=1;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        inputX = Input.GetAxisRaw("Horizontal");
        inputY = Input.GetAxisRaw("Vertical");
        Vector2 input = (transform.right * inputX + transform.up * inputY).normalized;
        rb.velocity = input * speed;
        if(input!=Vector2.zero)
        {
            anim.SetBool("isMoving", true);
            stopX = inputX;
            stopY = inputY;
        }
        else
        {
            anim.SetBool("isMoving", false);
        }

        if (input.x > 0)
        {
            moveDir = 1;
        }
        else
        {
            moveDir = -1;
        }
        transform.localScale = transform.localScale.x * moveDir > 0 ? transform.localScale :
            new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);

        anim.SetFloat("InputX", stopX);
        anim.SetFloat("InputY", stopY);
    }
}

