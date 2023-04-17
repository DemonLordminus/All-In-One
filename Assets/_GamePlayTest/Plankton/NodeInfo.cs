using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeInfo : MonoBehaviour
{
    [CustomLabel("node之间拖拽的力")] public float dragForce;
    [CustomLabel("node之间不发力的距离")] public float minDistanceWhenNonForce;
    [CustomLabel("不发力时是否强制速度归零")] public bool isForeZeroWhenNonForce;
    [CustomLabel("旋转速度")] public float rotationSpeed;
    [CustomLabel("头部速度")] public float headSpeed;
    
    [CustomLabel("身体预制体")] public GameObject bodyPerfab;
    [EditorButton("创建新身体")]
    public void CreateNewNode(BodyNode head)
    {
        var nextNode = head.behindNode;
        var newNode = Instantiate(bodyPerfab, head.transform.parent).GetComponent<BodyNode>();
        newNode.transform.position = nextNode.transform.position;
        newNode.behindNode = nextNode;
        head.behindNode = newNode;
        newNode.frontNode = head;
        nextNode.frontNode = newNode;
    }
}
