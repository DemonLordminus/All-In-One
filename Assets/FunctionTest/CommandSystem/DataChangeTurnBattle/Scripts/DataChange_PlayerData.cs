using DataChange;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DataChange
{
    public class DataChange_PlayerData : DataChange_PublicData
    {
        public GameObject nowTarget;
        private Damage damage;
        private SkillTest skillTest;
      

        [EditorButton]
        public override void TurnAction() //这个是假设每回合稳定触发的被动技能
        {
            BasicAttack(nowTarget);
            //UseSkillTest();
        }

        //[EditorButton]
        private void BasicAttack(GameObject target)
        {
            damage = new Damage(attackPoint, target);
            DataChange_CommandManager.Instance.AddCommands(damage);
        }

        [EditorButton]
        private void UseSkillTest()
        {
            skillTest = new SkillTest();
            DataChange_CommandManager.Instance.AddCommands(skillTest);
        }

        [EditorButton]
        private void MoveTest(Vector3 moveDis)
        {
            Move moveTest = new Move(moveDis,gameObject);
            DataChange_CommandManager.Instance.AddCommands(moveTest);
        }
    }

}