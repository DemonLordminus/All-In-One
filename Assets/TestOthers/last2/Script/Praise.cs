using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Praise : MonoBehaviour
{
    public static bool isStrong = false;
    public Transform praiseTrans;

    private void Start()
    {
        praiseTrans = GetComponent<Transform>();
    }
    void Update()
    {
        Invoke("praiseGenerate", 1f);
        enabled = false;
    }

    public void praiseGenerate()
    {
        int rx = Random.Range(0, 20);
        int ry = Random.Range(0, 10);
        praiseTrans.position = new Vector2(rx, ry);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Pacman")
        {
            Destroy(gameObject);
            isStrong = true;
        }
    }
}
