using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Map : MonoBehaviour
{
    public int i = 0;

    public List<int> prei = new List<int>();
    public List<int> posti = new List<int>();

    public GameObject[] praise = new GameObject[6];

    public void Start()
    {
        for(int m = 0; m < 6; m++)
        {
            posti.Add(m);
        }
        i = Random.Range(0, 6);
        StartCoroutine(praiseGenerate());
        StartCoroutine(GuangJingGenerate());
        StartCoroutine(RiXiangGenerate());
    }

    IEnumerator praiseGenerate()
    {
        if(posti.Contains(i) == true)
        {
            praise[i].SetActive(true);
        }
        if(prei.Contains(i) == false)
        {
            prei.Add(i);
        }
        posti.Remove(i);
        i = Random.Range(0, 6);
        yield return new WaitForSeconds(1f);
        StartCoroutine(praiseGenerate());
    }

    IEnumerator GuangJingGenerate()
    {
        yield return null;
    }

    IEnumerator RiXiangGenerate()
    {
        yield return null;
    }
}
