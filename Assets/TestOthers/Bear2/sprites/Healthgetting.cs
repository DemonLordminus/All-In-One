using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Healthgetting : MonoBehaviour
{
    //��ݮ�ӵ�Ѫ
    public int amount = 1;
  
    //��¼��ײ����
    int CollideCount;

    //��Ӵ�������ײ�¼�����ײִ�д���
    private void OnTriggerEnter2D(Collider2D other)
    {
        CollideCount = CollideCount + 1;
        
        //Ruby�ű������õ��Լ������õ����
        PlayerControl rubyCotroller = other.GetComponent<PlayerControl>();
       
            Debug.Log("��ǰѪ��" + rubyCotroller.currentHealth);
           
                //�ݻٵ�ǰ����Ϸ���� ��ݮ������
                Destroy(gameObject);
            }
          
         
         

            
          
              
            
        
    }

