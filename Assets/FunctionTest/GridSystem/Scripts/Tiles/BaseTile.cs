using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GridTest
{
    public class BaseTile : MonoBehaviour
    {
        //[SerializeField] private bool isBackground;//是否是背景，反之则为某一具体物体
        [SerializeField] private Color _baseColor, _offsetColor;
        [SerializeField] private SpriteRenderer _renderer;
        [SerializeField] private GameObject _highLight;
        [SerializeField] private bool _isWalkable;

        public BaseUnit OccupiedUnit;
        public bool Walkable => _isWalkable && OccupiedUnit == null;

        [EditorButton]
        public void testWalkable()
        {
            Debug.Log(Walkable);
        }

        #region AutoButton
        [EditorButton]
        public void AutoSetRenderer()
        {
           _renderer = GetComponent<SpriteRenderer>();
        }
        #endregion
        #region AutoButton
        [EditorButton]
        public void AutoSetHighLight()
        {
            _highLight = transform.GetChild(0).gameObject;
        }
        #endregion
        private int x, y;


        public void SetTileXY(int _x,int _y)
        {
            x= _x;
            y= _y;
        }
        public virtual void Init(int _x,int _y)
        {
            var isOffset = ((_x + _y) % 2 == 0);
            _renderer.color = isOffset? _baseColor : _offsetColor;
        }

        private void OnMouseEnter()
        {
            _highLight.SetActive(true);
        }
        private void OnMouseExit() 
        {
            _highLight.SetActive(false);
        }
    }
}
