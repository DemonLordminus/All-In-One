using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG;
using DG.Tweening;

public class BodyNode : MonoBehaviour
{
    [CustomLabel("这个node是不是头部")]public bool isHead;

    [CustomLabel("前面的节点")]public BodyNode frontNode;
    [CustomLabel("后面的节点")]public BodyNode behindNode;
    [CustomLabel("当前节点的头")]public Transform frontTrans;
    [CustomLabel("当前节点的尾")]public Transform backTrans;
    private Rigidbody2D rb;
    [SerializeField] private NodeInfo nodeInfo;


    [EditorButton()]
    public void SetNodeInfo()
    {
        nodeInfo = transform.parent.GetComponent<NodeInfo>();
        if (nodeInfo == null) { Debug.LogError("nodeInfo获取失败", gameObject); }
    }
    
    private void Start()
    {
        if(nodeInfo== null) { SetNodeInfo(); }
        rb=GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (isHead)
        {
            if(Input.GetMouseButton(0))
            {
                var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector3 dir = (mousePos - transform.position).normalized;
                rb.velocity = LookAt2DTool.GetFaceDirection(transform) * nodeInfo.headSpeed;
                var targetRotation = LookAt2DTool.LookAt2DAddRotation(transform,transform.position+dir, 90);
                //Debug.Log(targetRotation.z);
                transform.eulerAngles += new Vector3(0, 0, Mathf.Clamp(targetRotation.z, -nodeInfo.rotationSpeed, nodeInfo.rotationSpeed));
            }
            
        }
        else
        {
            MoveToFrontNode();
        }
    }
    private void OnDrawGizmosSelected()
    {
        if (nodeInfo == null) { SetNodeInfo(); }
        if (frontTrans != null)
        {
            Gizmos.DrawWireSphere(frontTrans.position, nodeInfo.minDistanceWhenNonForce);
            //if (!Application.isEditor)
            //{
            //    Gizmos.DrawLine(transform.position,LookAt2DTool.LookAt2D(transform, frontNode.backTrans.position));
            //}
            Gizmos.color = Color.red;
            Gizmos.DrawRay(transform.position, frontNode.transform.position - transform.position);
            Gizmos.color = Color.green;
            //var targetRotation = Mathf.Clamp(LookAt2DTool.LookAt2D(transform, frontNode.transform.position, -90).z, -nodeInfo.rotationSpeed, nodeInfo.rotationSpeed);
            //Gizmos.DrawRay(transform.position,new Vector3(Mathf.Sin(targetRotation),Mathf.Cos(targetRotation),0));
        }    
    }
    public void MoveToFrontNode()
    {
        if(frontNode!=null)
        {
            Vector3 distance = frontNode.backTrans.position - frontTrans.position;
            if(distance.sqrMagnitude > nodeInfo.minDistanceWhenNonForce * nodeInfo.minDistanceWhenNonForce)
            {
                //rb.velocity = (Vector2) distance * nodeInfo.dragForce;
                rb.velocity = (frontTrans.position - transform.position) * distance.magnitude * nodeInfo.dragForce;
                //rb.AddForce(distance * nodeInfo.dragForce, ForceMode2D.Force);
            }
            else 
            {
                if(nodeInfo.isForeZeroWhenNonForce)
                { 
                    rb.velocity = Vector3.zero;
                }
            }
            LookAt2DTool.LookAt2DWithWorldPosition(transform, frontNode.backTrans.position,90);
            //var dir=LookAt2DTool.LookAt2D(transform,frontNode.transform.position,90);
            ////Debug.Log(dir);
            //transform.eulerAngles = dir;
            ////rb.rotation = dir.z;
            ////transform.DORotate(dir, nodeInfo.rotationTime, RotateMode.Fast);
            //Vector3 dir = frontNode.transform.position - transform.position;
            //var targetRotation = Mathf.Clamp(LookAt2DTool.LookAt2DAddRotation(transform, frontNode.transform.position, 90).z, -nodeInfo.rotationSpeed, nodeInfo.rotationSpeed);
            //Debug.Log(targetRotation);
            //transform.eulerAngles += new Vector3(0,0, targetRotation);
        }
    }
}
    