using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LookAt2DTool 
{
    public static Vector3 LookAt2D(Transform from, Vector3 to)
    {
        float dx = to.x - from.transform.position.x;
        float dy = to.y - from.transform.position.y;
        float rotationZ = Mathf.Atan2(dy, dx) * 180 / Mathf.PI;
        //rotationZ -= 90;

        float originRotationZ = from.eulerAngles.z;
        float addRotationZ = rotationZ - originRotationZ;
        if (addRotationZ > 180)
            addRotationZ -= 360;

        return new Vector3(0, 0, addRotationZ);
    }

}
