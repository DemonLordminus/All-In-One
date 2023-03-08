using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GridTest
{
    public class GridManager : MonoBehaviour
    {
        [SerializeField] private int _totalWidth, _totalHeight;
        //[SerializeField] private BaseTile _tilePrefabs;
        [SerializeField] private Transform _camTransform;

        [SerializeField] private Transform _tileFather;

        [System.Serializable]
        #region Tile·Ö×é
        public class TileClass
        {
            [SerializeField] public BaseTile GrassTile;
            [SerializeField] public BaseTile MountainTile;
        }
        #endregion
        [SerializeField] private TileClass _tileClass;

        private Dictionary<Vector2, BaseTile> _tiles;

        private void Start()
        {
            //GenerateGrid();
        }

        [EditorButton]
        void GenerateGrid()
        {
            _tiles = new Dictionary<Vector2, BaseTile>();
            for (int nowX = 0; nowX < _totalWidth; nowX++)
            {
                for (int nowY = 0; nowY < _totalHeight; nowY++)
                {
                    var spawnedTile = Instantiate(_tileClass.GrassTile, new Vector3(nowX, nowY), Quaternion.identity);
                    spawnedTile.name = $"tileGrid{nowX}{nowY}";

                    spawnedTile.SetTileXY(nowX, nowY);
                    spawnedTile.Init(nowX, nowY);
                    _tiles[new Vector2(nowX, nowY)] = spawnedTile;
                }
            }

            _camTransform.position = new Vector3((float)_totalWidth / 2 - 0.5f, (float)_totalHeight / 2 - 0.5f, -10);
        }

        [EditorButton]
        public void AnotherGenerateGrid(int _widthCount,int _hightCount)
        {
            for (int _w = 0; _w < _widthCount; _w++)
            {
                for (int _h = 0; _h < _hightCount; _h++)
                {
                    var spawnedTile = Instantiate(_tileClass.GrassTile,_tileFather);
                    spawnedTile.Init(_w,_h);
                }
            }
        }

        public BaseTile GetTileAtPosition(Vector2 pos)
        {
            if (_tiles.TryGetValue(pos,out var tile))
            {
                return tile;
            }
            return null;
        }
    }
}
