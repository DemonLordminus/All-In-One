using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : MonoBehaviour
{
    //bool ÅÐ¶ÏÇé¿ö
    public bool isHook;
    public Transform aimPoint;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isHook)
        {
            return;
        }
        var interactive = collision.gameObject.GetComponent<Interactive>();
        if(interactive!=null)
        {
            Debug.Log("yes");
            interactive.hookObject = this.gameObject;
            interactive.OnAction();
        }
    }
}
