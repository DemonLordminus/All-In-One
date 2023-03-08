using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EventTest
{
    public class EventTest_EventListner : MonoBehaviour
    {
        private void OnEnable()
        {
            EventTest_EventHandler.actionForTest1 += Test1;
        }

        private void OnDisable()
        {
            EventTest_EventHandler.actionForTest1 -= Test1;
        }
        private void Test1()
        {
            Debug.Log("test1");
        }

    }
}