using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Escape : MonoBehaviour
{
    public AIDestinationSetter escapePoint;
    public Transform transOwn;//��¼��������λ��
    public Transform transRightUp, transRightDown, transLeftUp, transLeftDown;//��¼��ͼ�߽��ĸ����λ��
    public Transform player;//��¼���λ��

    private void Start()
    {
        escapePoint = GetComponent<AIDestinationSetter>();
        transOwn = GetComponent<Transform>();
    }

    private void Update()
    {
        escape();
    }

    //�����ǿ��ʱ�����˻����ͼ�߽�����
    public void escape()
    {
        if (Praise.isStrong)
        {
            if (transOwn.position.x < player.transform.position.x &&
                   transOwn.position.y < player.transform.position.y)
            {
                escapePoint.target = transLeftDown;//�����½�����
            }
            else if (transOwn.position.x < player.transform.position.x &&
                    transOwn.position.y >= player.transform.position.y)
            {
                escapePoint.target = transLeftUp;//�����Ͻ�����
            }
            else if (transOwn.position.x >= player.transform.position.x &&
                    transOwn.position.y < player.transform.position.y)
            {
                escapePoint.target = transRightDown;//�����½�����
            }
            else if (transOwn.position.x >= player.transform.position.x &&
                    transOwn.position.y >= player.transform.position.y)
            {
                escapePoint.target = transRightUp;//�����Ͻ�����
            }
            else//�ų��������
            {
                //�������������ʱ������������ͼ���ĸ����ƶ�
                int r = Random.Range(0, 4);
                if (r == 0)
                {
                    escapePoint.target = transRightUp;
                }
                else if (r == 1)
                {
                    escapePoint.target = transRightDown;
                }
                else if (r == 2)
                {
                    escapePoint.target = transLeftUp;
                }
                else
                {
                    escapePoint.target = transLeftDown;
                }
            }
        }
        Invoke("beWeak", 10f);
    }

    //���ʧȥǿ��״̬
    public void beWeak()
    {
        Praise.isStrong = false;
        escapePoint.target = player;
    }
}

