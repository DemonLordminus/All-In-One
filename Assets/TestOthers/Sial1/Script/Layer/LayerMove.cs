using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LayerMove : Get_Y_Axis
{
    public GameObject[] Cubes;
    private Vector3 distance;
    public float high;
    public float low;
    Vector3 MousePos,lastMousePos=Vector3.zero;

    private Rigidbody2D[] rb2ds;
    private void Start()
    {
        rb2ds = GetComponentsInChildren<Rigidbody2D>();
    }
    private void OnMouseDrag()
    {
        //TODO:ÐÞ¸Ä1
        MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (lastMousePos != Vector3.zero)
        {
            distance = MousePos - lastMousePos;
        }
        distance = new Vector3(distance.x, 0, 0);
        //for (int i = 0; i < Cubes.Length; ++i)
        //{
        //    //Cubes[i].transform.position = new Vector3(distance.x + Cubes[i].transform.position.x, Cubes[i].transform.position.y, Cubes[i].transform.position.z);
        //}
        foreach (Rigidbody2D rb in rb2ds)
        {
            rb.MovePosition(rb.transform.position+distance);
        }
        lastMousePos = MousePos;
    }

}
