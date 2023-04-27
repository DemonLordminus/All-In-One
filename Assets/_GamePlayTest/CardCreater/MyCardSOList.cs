using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "new MyCardSOList", menuName = "CardCreator/MyCardSOList", order = 1)]
public class MyCardSOList : ScriptableObject
{
    public List<MyCard> list;
}
