using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Escape : MonoBehaviour
{
    public AIDestinationSetter escapePoint;
    public Transform transOwn;
    public Transform transRightUp, transRightDown, transLeftUp, transLeftDown;
    public Transform player;

    private void Start()
    {
        escapePoint = GetComponent<AIDestinationSetter>();
        transOwn = GetComponent<Transform>();
    }
    private void Update()
    {
        escape();
    }
    public void escape()
    {
        if (Praise.isStrong)
        {
            if (transOwn.position.x < player.transform.position.x &&
                   transOwn.position.y < player.transform.position.y)
            {
                escapePoint.target = transLeftDown;
            }
            else if (transOwn.position.x < player.transform.position.x &&
                    transOwn.position.y >= player.transform.position.y)
            {
                escapePoint.target = transLeftUp;
            }
            else if (transOwn.position.x >= player.transform.position.x &&
                    transOwn.position.y < player.transform.position.y)
            {
                escapePoint.target = transRightDown;
            }
            else if (transOwn.position.x >= player.transform.position.x &&
                    transOwn.position.y >= player.transform.position.y)
            {
                escapePoint.target = transRightUp;
            }
            else
            {
                int r = Random.Range(0, 4);
                if (r == 0)
                {
                    escapePoint.target = transRightUp;
                }
                else if (r == 1)
                {
                    escapePoint.target = transRightDown;
                }
                else if (r == 2)
                {
                    escapePoint.target = transLeftUp;
                }
                else
                {
                    escapePoint.target = transLeftDown;
                }
            }
        }
        //Praise.isStrong = false;
    }
}
