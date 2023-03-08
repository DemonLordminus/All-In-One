using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using DG.Tweening;

namespace ManMadeGod.DataChange
{
    public class DataChangeManager : MonoBehaviour
    {
        #region DataPart
        [SerializeField] private List<GameObject> _dataButtonPrefabsList;
        [SerializeField] private GameObject _linkPrefabs;
        private List<DataChangeLink> _linkList;
        [SerializeField] private float _radius;
        [SerializeField] private Transform _dataButtonCenter;
        private bool isHold;
        private DataChangeLink nowLink;
        [SerializeField] private float _linkWidthOffset;
        private float _linkWidth => (float)_linkPrefabs.GetComponent<SpriteRenderer>()?.bounds.size.x - _linkWidthOffset;
        [SerializeField] private List<GameObject> _dataButtonInstanceList;

        #endregion
        #region CreateButton
        [EditorButton]
        private void dataButtonCreate()
        {
            
            ClearInstanceButton();
            float aveAngle = 2 * Mathf.PI / _dataButtonPrefabsList.Count;
            for (int count = 0; count < _dataButtonPrefabsList.Count; count++)
            {
                GameObject dataButton = Instantiate(_dataButtonPrefabsList[count], _dataButtonCenter);
                float nowAngle = aveAngle * count;
                Vector3 nowOffset = new Vector3(_radius * Mathf.Cos(nowAngle), _radius * Mathf.Sin(nowAngle));
                Vector3 dataButtonPos = _dataButtonCenter.position + nowOffset;
                dataButton.transform.position = dataButtonPos;
                _dataButtonInstanceList.Add(dataButton);
            }
            if (!Application.isEditor)
            {
                _dataButtonCenter.transform.DOScale(0, 0.01f);
                _dataButtonCenter.transform.DOScale(1, 1f);
            }
            } 
#endregion
#region LinkPart

        public void OnClick(InputValue value)
        {
            if (value.isPressed == true)
            {
                WhenPress();
            }
            else
            {
                WhenRelease();
            }
        }

        private DataChangeButton _lastClickOne;
        private void WhenPress()
        {
            DataChangeButton ClickedOne = GetClickedButton();
            if (ClickedOne != null)
            {
                nowLink = Instantiate(_linkPrefabs, ClickedOne.transform).GetComponent<DataChangeLink>();
                nowLink.transform.position = ClickedOne.transform.position;
                isHold = true;
                _lastClickOne = ClickedOne;
            }
        }
        private void WhenRelease()
        {
            if (isHold)
            {
                DataChangeButton ClickedOne = GetClickedButton();
                if (ClickedOne != null && ClickedOne != _lastClickOne)
                {
                    LinkTransformChange(ClickedOne.transform.position);
                    nowLink.SetWay(_lastClickOne, ClickedOne);
                    _linkList.Add(nowLink);
                }
                else
                {
                    _lastClickOne = null;
                    Destroy(nowLink.gameObject);
                }
                isHold = false;
                nowLink = null;
            }
        }
        private void LinkTransformChange(Vector2 target)
        {
            float distance = Vector2.Distance(target, _lastClickOne.transform.position);
            float scaleX = distance / _linkWidth;
            nowLink.transform.localScale = new Vector2(scaleX, nowLink.transform.localScale.y);
            nowLink.transform.eulerAngles = LookAt2DTool.LookAt2D(_lastClickOne.transform, target);
        }

        //获取点击的属性按钮
        private DataChangeButton GetClickedButton()
        {
            RaycastHit2D mouseHit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            DataChangeButton _get;
            if (mouseHit.collider != null)
            {
                if (_dataButtonInstanceList.Contains(mouseHit.collider.gameObject))
                {
                    if (mouseHit.collider.TryGetComponent<DataChangeButton>(out _get))
                    {
                        return _get;
                    }
                }
            }
            return null;
        } 
       
        private void Update()
        {
            if(isHold)
            {
                LinkTransformChange(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            }
        }

        /// <summary>
        /// 清除link列表以及其实例
        /// </summary>
        public void ClearLink()
        {
            for (int count = 0; count < _linkList.Count; count++)
            {
                Destroy(_linkList[count].gameObject);
            }
            _linkList.Clear();
        }
#endregion
#region clearList
        private void clearList<T>(T list) where T : List<GameObject>
        {
            for (int count = 0; count < list.Count; count++)
            {
                if (!Application.isEditor)
                {
                    DestroyImmediate(list[count].gameObject);
                }
                else
                {
                    Destroy(list[count]);
                }
            }
            list.Clear();
        }
#endregion

        [EditorButton]
        private void ClearInstanceButton()
        {
            if (_dataButtonInstanceList != null)
            {
                clearList(_dataButtonInstanceList);
            }
        }
    }
}