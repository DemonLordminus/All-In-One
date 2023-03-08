using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EventTest
{
    public class EventTest_EventTrigger : MonoBehaviour
    {
        [EditorButton]
        public void Call()
        {
            EventTest_EventHandler.CallAction(1,"1");
        }
    }
}
