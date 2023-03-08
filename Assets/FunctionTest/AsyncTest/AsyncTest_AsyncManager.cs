using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace AsyncTest
{
    public class AsyncTest_AsyncManager : MonoBehaviour
    {
        [SerializeField]
        private AsyncTest_Operator[] myOperator;
        [EditorButton]
        public async void HandleAction()
        {
            foreach (AsyncTest_Operator op in myOperator)
            {
                await op.Action();
            }
            //await Task.WhenAll();
        }
    }
}