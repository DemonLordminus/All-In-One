using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardCreator : MonoBehaviour
{
    public GameObject emptyCardPerfab;

    //实现创建卡牌的工厂模式
    [EditorButton]
    public void CreateNewCreateFromSO(MyCardSO so)
    {
        //通过一个SO文件，创建一个对应的Card
        Debug.Log("卡牌创建执行");
        var newCard = Instantiate(emptyCardPerfab);
        var cardIns = newCard.GetComponent<MyCardInstance>();
        cardIns.cardInfo = new MyCard(so.card);
        cardIns.SetNameAndRender();
    }
}
