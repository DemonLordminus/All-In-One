using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy5 : MonoBehaviour
{
    public People target;
    private void OnEnable()
    {
        target.OnTakeDamage += BecomeCrazy;   
    }
    private void OnDisable()
    {
        target.OnTakeDamage -= BecomeCrazy;
    }
    public void BecomeCrazy(int i)
    {
        Debug.Log("µÐÈË·è¿ñ");
    }
}
