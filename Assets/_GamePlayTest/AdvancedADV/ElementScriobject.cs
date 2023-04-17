using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new AdvElement", menuName = "AdvancedAdv/AdvElement", order = 1)]
public class ElementScriobject : ScriptableObject
{
    public AdvElement content;
    public static void CreateFromSo(GameObject target,ElementScriobject so)
    {
        var t=target.AddComponent<ElementBase>();
        t.content = so.content;
    }
}


