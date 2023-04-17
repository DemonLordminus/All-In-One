using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AirshipController : MonoBehaviour
{
    //参数带入
    public Vector3 PlayerInput;
    //刚体声明
    Rigidbody2D rigidbody2D;
    //速度
    private float horizontal;
    private float vertical;
    public float rotateSpeed;
    public float MoveSpeed;
    public Transform point;
    //水滴对象选择
    public GameObject waterPrefab;
    //水滴冷却时间调用
    public float waterLaunchCooldown;
    [SerializeField] private bool isWaterLaunchAvailable;
    private float nowCooldown;
    //使用linerenderer射线

    public LineRenderer lineRenderer;
    public Transform hookHead;

    public int waterMaxCount;
    //水滴速度
    [Header("水滴速度")]
    public float WaterSpeed;
    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        hookHead.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (hookRope == null)
            Move();
        else
            rigidbody2D.velocity = Vector2.zero;
        //检测按键输入
        if (Input.GetKeyDown(KeyCode.J))
        {
            Debug.Log("按下J键，发射子弹");//很重要
            Launch();
        }

        if (Input.GetKeyDown(KeyCode.K))
        {

            if (hookRope != null)
            {

            }
            else
            {
                hookRope = StartCoroutine(OnHookRope());
            }


        }

       // particleTrailer();
    }



    //抓钩系统
    Coroutine hookRope;
    public float lineLong;
    public float lineTime;
    //打开对应的层
    public LayerMask lineMask;
    public float lineCurrentLong;
    public Hook hook;
    [HideInInspector] public float hookSpeedRate;
    [SerializeField] private Vector3 lineNextPos;
    //抓钩
    IEnumerator OnHookRope()
    {
        //声明刚体对象
        rigidbody2D.velocity = Vector3.zero;
        lineCurrentLong = float.Epsilon;
        //使之平滑
        float lineSpeed = lineLong / lineTime;
        //获得初始点
        lineRenderer.SetPosition(0, point.position);
        lineNextPos = point.position;
        //钩索头显示
        hookHead.gameObject.SetActive(true);


        //钩索出去
        while (lineCurrentLong <= lineLong&&!hook.isHook)
        {
            var curretnFrameLength = lineSpeed * Time.deltaTime;
            LineNextPos += transform.up.normalized * curretnFrameLength;
            //出发点

            lineRenderer.SetPosition(1, LineNextPos);
            hookHead.position = lineNextPos;
            lineCurrentLong += curretnFrameLength;
            yield return new WaitForEndOfFrame();
        }
        //钩索伸回来
        while (lineCurrentLong >= 0)
        {
            //var  让编辑器自动推导
            var curretnFrameLength = lineSpeed * Time.deltaTime * hookSpeedRate;
            //递减
            LineNextPos -= transform.up.normalized * curretnFrameLength;
            lineRenderer.SetPosition(1, LineNextPos);
            //钩子头
            hookHead.position = lineNextPos;
            lineCurrentLong -= curretnFrameLength;
            yield return new WaitForEndOfFrame();
        }
        //判定刷到没有
        hook.isHook= false;
        //set position
        lineRenderer.SetPosition(1, point.position);
        hookHead.gameObject.SetActive(false);
        hookRope = null;
    }


    //移动
    Vector3 moveDirection;
    void Move()
    {
        float h = Input.GetAxis("Horizontal");//转向
        float v = Input.GetAxis("Vertical");//前后
                                            //角色移动代码
        moveDirection = transform.up * -1f;//获取当前朝向向量

        if (v >= 0)
        {
            transform.Rotate(new Vector3(0, 0, -h) * rotateSpeed * Time.deltaTime); //左右旋转
        }
        else
        {
            transform.Rotate(new Vector3(0, 0, h) * rotateSpeed * Time.deltaTime); //倒车时反转控制

        }

        if (v != 0)
        {
            rigidbody2D.AddForce(moveDirection * v * MoveSpeed);//按键时移动

            rigidbody2D.velocity = Vector2.zero;//消除刚力，否则会一直移动
        }
        else
        {
            rigidbody2D.velocity = Vector2.zero;//消除刚力，否则会一直移动
        }

    }

    Coroutine TimeIndex;

    public Vector3 LineNextPos { get => lineNextPos; set => lineNextPos = value; }

    IEnumerator CoolDownHandle()
    {
        //有bug的冷却时间写法
        //while (!isWaterLaunchAvailable)
        //{
        //    //nowCooldown -= Time.deltaTime;
        //    if ((nowCooldown -= Time.deltaTime) <= 0)
        //    {
        //        isWaterLaunchAvailable = true;
        //        nowCooldown = waterLaunchCooldown;
        //    }
        //    yield return new WaitForEndOfFrame();
        //    
        //}
        //协程的冷却方法
        yield return new WaitForSeconds(waterLaunchCooldown);
        isWaterLaunchAvailable = true;
    }

    //发射系统
    void Launch()
    {
        if (water.count < waterMaxCount)
        {
            if (isWaterLaunchAvailable)
            {
                //Debug.Log(Quaternion.Euler(0, 0, transform.rotation.z));
                Debug.Log(transform.rotation);
                //生成水滴位置
                GameObject projectilePrefab = Instantiate(waterPrefab, point.position, transform.rotation);
                //get组件
                Rigidbody2D waterRb = projectilePrefab.GetComponent<Rigidbody2D>();
                //一点点速度帧率变化
                waterRb.velocity = WaterSpeed * (point.transform.position - transform.position);
                isWaterLaunchAvailable = false;
                if (TimeIndex != null)
                {
                    StopCoroutine(TimeIndex);
                }
                TimeIndex = StartCoroutine(CoolDownHandle());
            }
            else
            {
                //Debug.LogFormat("冷却中，无法发射,剩余CD还剩:{0}",nowCooldown);
                Debug.Log($"冷却中,无法发射,剩余CD还剩:{nowCooldown}");
            }
        }
        else
        {
            Debug.LogFormat("水滴个数达到上限，无法发射");

        }
    }


    [Header("粒子拖尾")]
    //粒子效果拖尾
    public ParticleSystem particle;
    public float particleLifeCycle;
    [Header("粒子拖尾单位时间分块")]
    public float subsection;
  
    Vector2 prevPos = Vector2.zero;

 //  void particleTrailer()
 //  {
 //
 //      var currentPos = transform.position;
 //
 //      float length = Vector3.(currentPos, prevPos);
 //      var main = particle.main;
 //      //magnitude是大小意思
 //      main.startLifetime = subsection*length;
 //
 //
 //
 //  }
}






