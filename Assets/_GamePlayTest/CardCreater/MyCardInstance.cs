using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

//��ſ���ʵ����Ϣ
public class MyCardInstance : MonoBehaviour
{
    public MyCard cardInfo;
    public TextMeshPro cardNameText;
    public SpriteRenderer cardRenderer;
    public void SetNameAndRender(string cardName,Sprite cardSprite)
    {
        cardNameText.text = cardName;
        cardRenderer.sprite = cardSprite;
    }
    public void SetNameAndRender()
    {
        cardNameText.text = cardInfo.cardName;
        cardRenderer.sprite = cardInfo.cardSprite;
    }
}
