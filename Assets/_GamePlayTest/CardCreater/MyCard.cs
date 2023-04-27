using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]//���л�
public class MyCard
{
    public int cardId;
    public string cardName;
    public Sprite cardSprite;
    public paradigm cardParadigm;
    public int cardRange;

    public List<EffectForStore> effectsForStore;
    public List<CardEffect> effects;

    public People[] target;
    public int targetNumber;


    public MyCard(){  }
    public void Init()//��ʼ�� �ǵ��ڿ������ɵ�ʱ�����һ��
    {
        foreach(var e in effectsForStore)
        {
            effects.Add(e.Apply());
        }
    }
    public MyCard(MyCard old)
    {
        cardSprite = old.cardSprite;
        cardName = old.cardName;
        cardParadigm =old.cardParadigm;
        cardRange =old.cardRange;
        cardId = old.cardId;
    }
    public void EffectApply()
    {
        if (targetNumber == 0)
        { }
        else if (targetNumber == 1)
        { }
        else if(targetNumber >1 ) { }

        foreach(var effect in effects)
        {
            effect.EffectExcute(target.ToList());
        }
    }

}
[Serializable]
public class EffectForStore
{
    public effectName effectID;
    public List<float> values;
    public CardEffect Apply()
    {
        switch(effectID)
        {
            case effectName.damage:return new Damage((int)values[0]);
        }
        return null;
    }
}
public enum effectName
{
    damage=0,
}

public enum paradigm
{
    empty=0,
    attack,
    defend,
    AOE
}


//public class CardEffect
//{
// //Ч������
//}
public interface CardEffect //�ӿ�
{
    public void EffectExcute();
    public void EffectExcute(People target);
    public void EffectExcute(List<People> targets);
}
public class People
{
    public int health;
    public int shield;
    public event Action<int> OnTakeDamage;
    public void TakeDamage(int damageValue)
    {
        if(shield>0)
        {
            shield -= 1;
        }
        else 
        {
            health -= damageValue;
        }
        OnTakeDamage?.Invoke(damageValue);
    }
}
public class Damage : CardEffect
{
    public int damageValue;
    public People target;
    public Damage(int damageValue, People target =null)
    {
        this.damageValue = damageValue;
        this.target = target;
    }
    public void EffectExcute()
    {
        EffectExcute(target);
    }

    public void EffectExcute(People targetCard)
    {
        //targetCard.health -= damageValue;
        targetCard.TakeDamage(damageValue);
    }

    public void EffectExcute(List<People> targetCards)
    {
        foreach(var target in targetCards)
        {
            EffectExcute(target);
        }
    }
}