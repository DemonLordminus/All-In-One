using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ManMadeGod.DataChange
{
	public class DataChangeLink : MonoBehaviour
	{
		public DataChangeButton from, to;
		public void SetWay(DataChangeButton _f,DataChangeButton _t)
		{
			from = _f;
			to = _t;
		}
	}

}