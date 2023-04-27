using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardCreator : MonoBehaviour
{
    public GameObject emptyCardPerfab;

    //ʵ�ִ������ƵĹ���ģʽ
    [EditorButton]
    public void CreateNewCreateFromSO(MyCardSO so)
    {
        //ͨ��һ��SO�ļ�������һ����Ӧ��Card
        Debug.Log("���ƴ���ִ��");
        var newCard = Instantiate(emptyCardPerfab);
        var cardIns = newCard.GetComponent<MyCardInstance>();
        cardIns.cardInfo = new MyCard(so.card);
        cardIns.SetNameAndRender();
    }
}
