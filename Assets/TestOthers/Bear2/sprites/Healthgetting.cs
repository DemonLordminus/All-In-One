using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Healthgetting : MonoBehaviour
{
    //草莓加的血
    public int amount = 1;
  
    //记录碰撞数字
    int CollideCount;

    //添加触发器碰撞事件，碰撞执行代码
    private void OnTriggerEnter2D(Collider2D other)
    {
        CollideCount = CollideCount + 1;
        
        //Ruby脚本对象拿到自己所设置的组件
        PlayerControl rubyCotroller = other.GetComponent<PlayerControl>();
       
            Debug.Log("当前血量" + rubyCotroller.currentHealth);
           
                //摧毁当前的游戏对象 草莓被吃了
                Destroy(gameObject);
            }
          
         
         

            
          
              
            
        
    }

