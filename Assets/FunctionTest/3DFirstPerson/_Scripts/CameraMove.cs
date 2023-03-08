using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _3DFP
{
    public class CameraMove : MonoBehaviour
    {
        public Transform cameraPosition;
        
        void Update()
        {
            transform.position = cameraPosition.position;
        }
    }

}