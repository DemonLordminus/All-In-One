using DataChange;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DataChange
{
    public abstract class DataChange_Command
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="owner">ִ����</param>
        /// <param name="target">Ŀ��</param>
        /// <param name="isForward">�Ƿ�Ϊ�����ж� false������</param>
        public abstract void Excute(bool isForward);
    }

    public class SkillTest : DataChange_Command
    {
        public override void Excute(bool isFoward)
        {
            if (isFoward)
            {
                Debug.Log("���������и����ܣ�������������");
            }
            else
            {
                Debug.Log("���������¼���������ܲ�����Ч���ָ���");

            }
           
        }
    }
    public class Damage : DataChange_Command
    {
        private float DamageValue;
        private GameObject target;
        public Damage(float _DamageValue, GameObject _target)
        {
            DamageValue = _DamageValue; 
            target = _target;
        }
        public override void Excute(bool isFoward)
        {
            if (isFoward)
            {
                Debug.Log("����ָ���"+target.name+"���"+DamageValue+"���˺�");
                target.GetComponent<DataChange_PublicData>()?.GetDamaged(DamageValue);   
            }
            else
            {
                Debug.Log("����ָ���" + target.name + "�ظ���" + DamageValue + "����ɹ����˺�");
                target.GetComponent<DataChange_PublicData>()?.GetDamaged(-DamageValue);
            }
        }
    }


    public class Move : DataChange_Command
    {
        private GameObject onwer;
        private Vector3 moveDis;
        public Move(Vector3 _moveDis, GameObject onwer)
        {
            this.moveDis = _moveDis;
            this.onwer = onwer;
        }
        public override void Excute(bool isForward)
        {
            if(isForward)
            {
                onwer.transform.position += moveDis;
            }
            else
            {
                onwer.transform.position -= moveDis;
            }
        }
    }

}//namespace��β����