using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{

     public string sceneFrom;

     public string sceneTOGO;

    public void TeleportToScene()
    {
        Debug.Log("Ïë´«ËÍ");
        TransitionManager.Instance.Transition(sceneFrom, sceneTOGO);
    }
}
