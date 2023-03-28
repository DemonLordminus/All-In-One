using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class Light : MonoBehaviour
{
    //判断玩家是否减速
    public static bool IsLowSpeed = false;
    //判断玩家是否离开光照区域
    public static bool IsExit = false;

    //判断玩家是否进入光照区域
    public static bool IsFire;
    public static Transform trans;

    public void Start()
    {
        trans = GetComponent<Transform>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Pacman")
        {
            IsLowSpeed = true;
            IsFire = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "Pacman")
        {
            IsFire = false;
            IsExit = true;
            Player.Hp = 1000;
        }
    }
}
