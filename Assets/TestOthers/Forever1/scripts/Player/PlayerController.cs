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

    [Header("基本参数")]
    public float speed;

    public float jumpForce;

    public float hurtForce;

    private float runSpeed;

    
    private float walkSpeed => speed / 2.4f;

    
    private CapsuleCollider2D coll;
    private Vector2 originalOffset;
    private Vector2 originalSize;

    [Header("物理材质")]
    public PhysicsMaterial2D normal;
    public PhysicsMaterial2D wall;

    [Header("状态")]
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
        //跳跃
        inputControl.Gameplay.Jump.started += Jump;

        //rb = GetComponent<Rigidbody2D>();
        #region 强制走路...
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

        //攻击
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
    //测试
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
        //人物翻转
        // transform.localScale = new Vector3(faceDir, 1, 1);

        //下蹲
        isCrouch = inputDirection.y < -0.5f && physicsCheck.isGround;
        if (isCrouch)
        {
            //修改碰撞体大小和位移
            coll.offset = new Vector2(-0.05f, 0.75f);
            coll.size = new Vector2(0.7f, 1.5f);
        }
        else
        {
            //还原之前的碰撞体参数
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
       //角色死亡避免被再攻击
        //if (isDead && isSlide)
        //    gameObject.layer = LayerMask.NameToLayer("Enemy");
        //else
        //    gameObject.layer = LayerMask.NameToLayer("Player");
    }
}
