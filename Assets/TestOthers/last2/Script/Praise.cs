using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Praise : MonoBehaviour
{
    public static bool isStrong = false;//判断玩家是否强化
    //public Transform praiseTrans;//记录点赞位置

    //private void Start()
    //{
    //    //praiseTrans = GetComponent<Transform>();
    //    //这一段代码有问题，不应该放在update里，具体的实现效果之后再说，我先移动到start里去了
    //    //Invoke("praiseGenerate", 5f);//使点赞产生随机出现在地图上的效果（不完善）
    //}

    //void Update()
    //{

    //    //enabled = false;
    //}

    //将点赞从地图外移入地图内
    //public void praiseGenerate()
    //{
    //    int rx = Random.Range(-3, 3);
    //    int ry = Random.Range(-3, 3);
    //    //生成在光照区域
    //    praiseTrans.position = new Vector2(Light.trans.position.x + rx, Light.trans.position.x + ry);
    //}

    //玩家获得点赞
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Pacman")
        {
            Destroy(gameObject);
            isStrong = true;
        }
    }
}
