using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeInfo : MonoBehaviour
{
    [CustomLabel("node֮����ק����")] public float dragForce;
    [CustomLabel("node֮�䲻�����ľ���")] public float minDistanceWhenNonForce;
    [CustomLabel("������ʱ�Ƿ�ǿ���ٶȹ���")] public bool isForeZeroWhenNonForce;
    [CustomLabel("��ת�ٶ�")] public float rotationSpeed;
    [CustomLabel("ͷ���ٶ�")] public float headSpeed;
    
    [CustomLabel("����Ԥ����")] public GameObject bodyPerfab;
    [EditorButton("����������")]
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
