using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum elementType
{
    empty,
    item,
    skill
}
public class ElementBase : MonoBehaviour
{
    public AdvElement content;

    private void OnMouseDrag()
    {
        Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(pos.x, pos.y, transform.position.z);
    }
}
[System.Serializable]
public class AdvElement
{
    //可加上构造函数，这里累了
    public int elementIndex;
    public string elementName;
    public elementType type;
    public int count;
}