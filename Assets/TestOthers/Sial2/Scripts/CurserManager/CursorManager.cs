using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    private Vector3 mouseWorldPos => Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
    // Start is called before the first frame update

    private bool canClick;

    private void Update()
    {
        canClick = ObjectAtMousPos();

        if (canClick && Input.GetMouseButtonDown(0)) 
        {
            ClickAtion(ObjectAtMousPos().gameObject);
        }
    }
    private void ClickAtion(GameObject clickObject)
    {
        Debug.Log("µã»÷ÁË");
        switch (clickObject.tag)
        {
            case "Teleport":
                var teleport = clickObject.GetComponent<Teleport>();
                teleport?.TeleportToScene();
                break;
        }
    }
    private Collider2D ObjectAtMousPos()
    {
        return Physics2D.OverlapPoint(mouseWorldPos);
    }
}
