using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DataChange
{
    /// <summary>
    /// �������������˶����е����ݣ��Ǹ���
    /// </summary>
    public abstract class DataChange_PublicData : MonoBehaviour
    {
        [SerializeField] protected float healthPoint;
        [SerializeField] protected float maxHealthPoint;
        [SerializeField] protected float attackPoint;
        [SerializeField] protected float speed;
        [SerializeField] protected float defend;

        public abstract void TurnAction();

        public void GetDamaged(float damaged)
        {
            healthPoint -= damaged;
        }
    }
}