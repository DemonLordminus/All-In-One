using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace EventTest
{
    public class EventTest_EventHandler : MonoBehaviour
    {
        //ί��д��
        public delegate void MyDelegate();
        //public event MyDelegate myEvent;
        //��Ч������д�� Func��һ������ֵ
        public static event Action actionForTest1;
        public static event Action<int,string> actionForTest2;

        public UnityAction unityActionTest1;//��ȷ����action��������
        public UnityEvent unityEventTest1;

        public static void CallAction(int i,string s)
        {
            actionForTest1?.Invoke();
            actionForTest2?.Invoke(i, s);
        }
        public void callUnityEvent()
        { 
            unityEventTest1?.AddListener(empty);
        }
        public void empty()
        { }
    }
}