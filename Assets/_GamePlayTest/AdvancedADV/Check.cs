using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Check : Singleton<Check>
{
    public List<ElementBase> nowElements;
    public List<AdvTurnSO> turns;
    public bool isNoMore;//没有多余的
    private void Start()
    {
        Debug.Log("当前可用的组合为:");
        foreach(var turn in turns)
        {
            Debug.Log(turn.nextTurnInfo);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log($"{collision.gameObject}拖入", collision.gameObject);
        ElementBase tmp;
        if(collision.gameObject.TryGetComponent<ElementBase>(out tmp))
        {
            nowElements.Add(tmp);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        ElementBase tmp;
        if (collision.gameObject.TryGetComponent<ElementBase>(out tmp))
        {
            if(nowElements.Contains(tmp))
            {
                nowElements.Remove(tmp);
            }
        }
    }
    public bool NameIndexCheck(AdvElement e1, AdvElement e2)
    { 
        return (e1.elementName==e2.elementName) && (e1.elementIndex == e2.elementIndex);
    }
    public bool ElementContains(List<AdvElement> list,ElementBase element)
    {
        foreach(var t in list)
        {
            if(NameIndexCheck(t,element.content))
            {
                return true; 
            }
        }
        return false;
    }

    [EditorButton("检测当前物品")]
    public void CheckElement()
    {
        int checkCount;
        foreach(var turn in turns)
        {
            checkCount = 0;
            bool flag = true;
            foreach(var element in nowElements)
            {
                if(!ElementContains(turn.requiredElements,element))
                {
                    flag=false;
                    break;
                }
                checkCount++;
            }
            if(flag && (!isNoMore || checkCount == turn.requiredElements.Count))
            { 
                Debug.Log($"所有条件凑齐,{turn}激活");
                break;
            }
        }
    }
}
