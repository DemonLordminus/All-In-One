using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AirshipController : MonoBehaviour
{
    //��������
    public Vector3 PlayerInput;
    //��������
    Rigidbody2D rigidbody2D;
    //�ٶ�
    private float horizontal;
    private float vertical;
    public float rotateSpeed;
    public float MoveSpeed;
    public Transform point;
    //ˮ�ζ���ѡ��
    public GameObject waterPrefab;
    //ˮ����ȴʱ�����
    public float waterLaunchCooldown;
    [SerializeField] private bool isWaterLaunchAvailable;
    private float nowCooldown;
    //ʹ��linerenderer����

    public LineRenderer lineRenderer;
    public Transform hookHead;

    public int waterMaxCount;
    //ˮ���ٶ�
    [Header("ˮ���ٶ�")]
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
        //��ⰴ������
        if (Input.GetKeyDown(KeyCode.J))
        {
            Debug.Log("����J���������ӵ�");//����Ҫ
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



    //ץ��ϵͳ
    Coroutine hookRope;
    public float lineLong;
    public float lineTime;
    //�򿪶�Ӧ�Ĳ�
    public LayerMask lineMask;
    public float lineCurrentLong;
    public Hook hook;
    [HideInInspector] public float hookSpeedRate;
    [SerializeField] private Vector3 lineNextPos;
    //ץ��
    IEnumerator OnHookRope()
    {
        //�����������
        rigidbody2D.velocity = Vector3.zero;
        lineCurrentLong = float.Epsilon;
        //ʹ֮ƽ��
        float lineSpeed = lineLong / lineTime;
        //��ó�ʼ��
        lineRenderer.SetPosition(0, point.position);
        lineNextPos = point.position;
        //����ͷ��ʾ
        hookHead.gameObject.SetActive(true);


        //������ȥ
        while (lineCurrentLong <= lineLong&&!hook.isHook)
        {
            var curretnFrameLength = lineSpeed * Time.deltaTime;
            LineNextPos += transform.up.normalized * curretnFrameLength;
            //������

            lineRenderer.SetPosition(1, LineNextPos);
            hookHead.position = lineNextPos;
            lineCurrentLong += curretnFrameLength;
            yield return new WaitForEndOfFrame();
        }
        //���������
        while (lineCurrentLong >= 0)
        {
            //var  �ñ༭���Զ��Ƶ�
            var curretnFrameLength = lineSpeed * Time.deltaTime * hookSpeedRate;
            //�ݼ�
            LineNextPos -= transform.up.normalized * curretnFrameLength;
            lineRenderer.SetPosition(1, LineNextPos);
            //����ͷ
            hookHead.position = lineNextPos;
            lineCurrentLong -= curretnFrameLength;
            yield return new WaitForEndOfFrame();
        }
        //�ж�ˢ��û��
        hook.isHook= false;
        //set position
        lineRenderer.SetPosition(1, point.position);
        hookHead.gameObject.SetActive(false);
        hookRope = null;
    }


    //�ƶ�
    Vector3 moveDirection;
    void Move()
    {
        float h = Input.GetAxis("Horizontal");//ת��
        float v = Input.GetAxis("Vertical");//ǰ��
                                            //��ɫ�ƶ�����
        moveDirection = transform.up * -1f;//��ȡ��ǰ��������

        if (v >= 0)
        {
            transform.Rotate(new Vector3(0, 0, -h) * rotateSpeed * Time.deltaTime); //������ת
        }
        else
        {
            transform.Rotate(new Vector3(0, 0, h) * rotateSpeed * Time.deltaTime); //����ʱ��ת����

        }

        if (v != 0)
        {
            rigidbody2D.AddForce(moveDirection * v * MoveSpeed);//����ʱ�ƶ�

            rigidbody2D.velocity = Vector2.zero;//���������������һֱ�ƶ�
        }
        else
        {
            rigidbody2D.velocity = Vector2.zero;//���������������һֱ�ƶ�
        }

    }

    Coroutine TimeIndex;

    public Vector3 LineNextPos { get => lineNextPos; set => lineNextPos = value; }

    IEnumerator CoolDownHandle()
    {
        //��bug����ȴʱ��д��
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
        //Э�̵���ȴ����
        yield return new WaitForSeconds(waterLaunchCooldown);
        isWaterLaunchAvailable = true;
    }

    //����ϵͳ
    void Launch()
    {
        if (water.count < waterMaxCount)
        {
            if (isWaterLaunchAvailable)
            {
                //Debug.Log(Quaternion.Euler(0, 0, transform.rotation.z));
                Debug.Log(transform.rotation);
                //����ˮ��λ��
                GameObject projectilePrefab = Instantiate(waterPrefab, point.position, transform.rotation);
                //get���
                Rigidbody2D waterRb = projectilePrefab.GetComponent<Rigidbody2D>();
                //һ����ٶ�֡�ʱ仯
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
                //Debug.LogFormat("��ȴ�У��޷�����,ʣ��CD��ʣ:{0}",nowCooldown);
                Debug.Log($"��ȴ��,�޷�����,ʣ��CD��ʣ:{nowCooldown}");
            }
        }
        else
        {
            Debug.LogFormat("ˮ�θ����ﵽ���ޣ��޷�����");

        }
    }


    [Header("������β")]
    //����Ч����β
    public ParticleSystem particle;
    public float particleLifeCycle;
    [Header("������β��λʱ��ֿ�")]
    public float subsection;
  
    Vector2 prevPos = Vector2.zero;

 //  void particleTrailer()
 //  {
 //
 //      var currentPos = transform.position;
 //
 //      float length = Vector3.(currentPos, prevPos);
 //      var main = particle.main;
 //      //magnitude�Ǵ�С��˼
 //      main.startLifetime = subsection*length;
 //
 //
 //
 //  }
}






