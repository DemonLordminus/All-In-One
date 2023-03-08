using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Tower1
{
    public class GirdManager : Singleton<GirdManager>
    {
        [SerializeField,CustomLabel("横排个数")] private int _widthCount;
        [SerializeField,CustomLabel("地板预制体")] private BaseFloor _floor;
        //[SerializeField]
         

    }

}