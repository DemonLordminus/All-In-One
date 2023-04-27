using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new MyCardSO", menuName = "CardCreator/MyCardSO", order = 1)]
public class MyCardSO : ScriptableObject
{
    public MyCard card;
}
