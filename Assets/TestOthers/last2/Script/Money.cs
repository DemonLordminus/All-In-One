using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Money : MonoBehaviour
{
    //ÊÕ¼¯½ð±Ò
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "Pacman")
        {
            Player.money++;
            Destroy(gameObject);
        }
    }
}
