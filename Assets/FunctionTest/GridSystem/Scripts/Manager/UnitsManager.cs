using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace GridTest
{
    public class UnitsManager : Singleton<UnitsManager>
    {
        public List<ScriptableUnit> _units;



        protected override void Awake()
        {
            base.Awake();
            _units = Resources.LoadAll<ScriptableUnit>("GridSystem/Units").ToList();
        }
        
        private T GetRandomUnit<T>(Faction faction) where T : BaseUnit
        {
            return (T)_units.Where(u => u.faction == faction).OrderBy(o => Random.value).First().UnitPrefab;
            //∏ﬂº∂”Ô∑®
        }

        [EditorButton]
        private void testSpawnHero()
        {
            var hero = GetRandomUnit<BaseHero>(Faction.Hero);
            Debug.Log(hero.name);
        }
    }
}