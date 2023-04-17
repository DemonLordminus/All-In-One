using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drangousarea : MonoBehaviour
{
   
    public int damageNum = -1;
    private void OnTriggerStay2D(Collider2D other)
    {
        //Åö×²¼õÑª
        PlayerControl rubyController = other.GetComponent<PlayerControl>();
        if (rubyController != null)
        {
            rubyController.ChangeHealth(damageNum);



        }



    }


}