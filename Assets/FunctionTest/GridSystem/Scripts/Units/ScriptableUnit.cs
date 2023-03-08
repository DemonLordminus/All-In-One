using GridTest;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GridTest
{
    [CreateAssetMenu(fileName = "NewUnit", menuName = "GridTest/Scriptable Unit", order = 1)]
    public class ScriptableUnit : ScriptableObject
    {
        public Faction faction;
        public BaseUnit UnitPrefab;
    }

    public enum Faction
    {
        None = -1,
        Hero = 0,
        Enemy = 1,
    } 
}