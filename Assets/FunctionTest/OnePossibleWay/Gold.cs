using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold : MonoBehaviour
{
    public int goldValue;//�����ҵļ�ֵ
    private void goldTouch()//���������ʱ�����ķ���
    {
        PlayerManager.instance.GetGold(goldValue);
        Debug.Log("�񵽽��");
        Destroy(this.gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        goldTouch();
    }
}
