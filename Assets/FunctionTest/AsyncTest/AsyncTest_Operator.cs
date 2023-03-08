using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class AsyncTest_Operator : MonoBehaviour
{
    public async Task Action()
    {
        Debug.Log(name+"¹¥»÷");
        await Task.Delay(1000);
        //await Task.Yield();
    }
}
