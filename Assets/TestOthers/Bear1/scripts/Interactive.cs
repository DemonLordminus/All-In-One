using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactive : MonoBehaviour
{
    public GameObject hookObject;
    public Star star;
    public float hookRate;
    private void Start()
    {
        //测试体
        try
        {
            star = GetComponent<Star>();
        }
        catch { }
    }

    public void OnAction()
    {
        try
        {
            star.enabled = false;
        }
        catch { }
        hookObject.GetComponent<Hook>().isHook = true;
        //TODO:自己去改！
        hookObject.transform.parent.transform.parent.GetComponent<AirshipController>().hookSpeedRate= hookRate; //这样写绝对不好
        StartCoroutine(Track());
    }
    //是否抓住
    IEnumerator Track()
    {
        while (hookObject.GetComponent<Hook>().isHook == true)
        {
            this.gameObject.transform.position = hookObject.GetComponent<Hook>().aimPoint.position;
            //Debug.Log(Vector3.Distance(this.gameObject.transform.position, Airship.transform.position));
            if (Mathf.Approximately(Vector3.Distance(this.gameObject.transform.position, hookObject.transform.parent.parent.position), 0))
                break;
            yield return new WaitForEndOfFrame();
        }
    }

}
