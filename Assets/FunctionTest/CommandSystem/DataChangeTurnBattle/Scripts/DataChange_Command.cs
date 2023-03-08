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
        /// <param name="owner">执行者</param>
        /// <param name="target">目标</param>
        /// <param name="isForward">是否为正向行动 false代表撤销</param>
        public abstract void Excute(bool isForward);
    }

    public class SkillTest : DataChange_Command
    {
        public override void Excute(bool isFoward)
        {
            if (isFoward)
            {
                Debug.Log("假设这里有个技能，现在它触发了");
            }
            else
            {
                Debug.Log("撤销技能事件，这个技能产生的效果恢复了");

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
                Debug.Log("正向指令：对"+target.name+"造成"+DamageValue+"点伤害");
                target.GetComponent<DataChange_PublicData>()?.GetDamaged(DamageValue);   
            }
            else
            {
                Debug.Log("撤销指令：对" + target.name + "回复了" + DamageValue + "点造成过的伤害");
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

}//namespace结尾括号