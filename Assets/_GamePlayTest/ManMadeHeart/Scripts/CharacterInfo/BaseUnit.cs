using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ManMadeGod.Unit
{
	[Serializable]
	public class BaseUnit : MonoBehaviour
	{
		const int propertyNumber = 6;
		[SerializeField]private int[] unitProperty=>new int[propertyNumber];
	
		public int getUnitProperty(unitPropertyName name)
		{
			return unitProperty[(int)name];
		}
		void test()
		{
			int i = getUnitProperty(unitPropertyName.Dream);	
		}
	}
}