using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace EventTest
{
    public class EventTest_EventHandler : MonoBehaviour
    {
        //委托写法
        public delegate void MyDelegate();
        //public event MyDelegate myEvent;
        //等效于下面写法 Func多一个返回值
        public static event Action actionForTest1;
        public static event Action<int,string> actionForTest2;

        public UnityAction unityActionTest1;//不确定与action区别在哪
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