using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold : MonoBehaviour
{
    public int goldValue;//这个金币的价值
    private void goldTouch()//触碰到金币时触发的方法
    {
        PlayerManager.instance.GetGold(goldValue);
        Debug.Log("捡到金币");
        Destroy(this.gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        goldTouch();
    }
}
