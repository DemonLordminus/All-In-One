using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public PlayerInputControl inputControl;
    public Vector2 inputDirection;
    public Rigidbody2D rb;
    public SpriteRenderer fl;
    private PhysicsCheck physicsCheck;
    private PlayerAnimation playerAnimation;

    [Header("��������")]
    public float speed;

    public float jumpForce;

    public float hurtForce;

    private float runSpeed;

    
    private float walkSpeed => speed / 2.4f;

    
    private CapsuleCollider2D coll;
    private Vector2 originalOffset;
    private Vector2 originalSize;

    [Header("�������")]
    public PhysicsMaterial2D normal;
    public PhysicsMaterial2D wall;

    [Header("״̬")]
    public bool isCrouch;
    
    public bool isHurt;
    public bool isDead;
    public bool isAttack;
   
     



    private void Awake()
    {
        inputControl = new PlayerInputControl();

        physicsCheck = GetComponent<PhysicsCheck>();

        coll = GetComponent<CapsuleCollider2D>();

        playerAnimation = GetComponent<PlayerAnimation>();

        originalOffset = coll.offset;
        originalSize = coll.size;
        //��Ծ
        inputControl.Gameplay.Jump.started += Jump;

        //rb = GetComponent<Rigidbody2D>();
        #region ǿ����·...
        runSpeed = speed;
        inputControl.Gameplay.Walkbutton.performed += ctx => 
        {
            if (physicsCheck.isGround)
                speed = walkSpeed;
        };
        inputControl.Gameplay.Walkbutton.canceled += ctx =>
        {
            if (physicsCheck.isGround)
                speed = runSpeed;
        };
        #endregion

        //����
        inputControl.Gameplay.Attack.started += PlayerAttack;
    }


    private void OnEnable()
    {
        inputControl.Enable();
    }
    private void OnDisable()
    {
        inputControl.Disable();
    }
    private void Update()
    {
        inputDirection = inputControl.Gameplay.Move.ReadValue<Vector2>();
        CheckState();
    }
    private void FixedUpdate()
    {
        if(!isHurt&&!isAttack)
        Move();
    }
    //����
   // private void OnTriggerStay2D(Collider2D collision)
    //{
    //    Debug.Log(collision.name);
    //}

    public void Move()
    {
        if(!isCrouch)
        rb.velocity = new Vector2(inputDirection.x * speed * Time.deltaTime, rb.velocity.y);
        // int faceDir = (int)transform.localScale.x;
        if (inputDirection.x > 0)
            fl.flipX = false;
        //faceDir = 1;
        if (inputDirection.x < 0)
            fl.flipX = true;
        //faceDir = -1;
        //���﷭ת
        // transform.localScale = new Vector3(faceDir, 1, 1);

        //�¶�
        isCrouch = inputDirection.y < -0.5f && physicsCheck.isGround;
        if (isCrouch)
        {
            //�޸���ײ���С��λ��
            coll.offset = new Vector2(-0.05f, 0.75f);
            coll.size = new Vector2(0.7f, 1.5f);
        }
        else
        {
            //��ԭ֮ǰ����ײ�����
            coll.size = originalSize;
            coll.offset = originalOffset;
        }

    }
    private void Jump(InputAction.CallbackContext obj)
    {
        // Debug.Log("jump");
        if(physicsCheck.isGround)
        rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
    }

    private void PlayerAttack(InputAction.CallbackContext obj)
    {
        playerAnimation.PlayerAttack();
        isAttack = true;
       

    }

    #region UnityEvent
    public void GetHurt(Transform attacker)
    {
        isHurt = true;
        rb.velocity = Vector2.zero;
        Vector2 dir = new Vector2((transform.position.x - attacker.position.x), 0).normalized;
        rb.AddForce(dir * hurtForce, ForceMode2D.Impulse);
    }
    public void PlayerDead()
    {
        isDead = true;
       inputControl.Gameplay.Disable();
    }
    #endregion

    private void CheckState()
    {
        coll.sharedMaterial = physicsCheck.isGround ? normal : wall;
       //��ɫ�������ⱻ�ٹ���
        //if (isDead && isSlide)
        //    gameObject.layer = LayerMask.NameToLayer("Enemy");
        //else
        //    gameObject.layer = LayerMask.NameToLayer("Player");
    }
}
