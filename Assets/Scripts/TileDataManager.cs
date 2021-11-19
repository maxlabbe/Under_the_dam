using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileDataManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Tilemap map;
    [SerializeField]
    private List<TileData> _tileData;
    private Dictionary<TileBase, TileData> _tileDataDict;

    private void Awake()
    {
        _tileDataDict = new Dictionary<TileBase, TileData>();
        foreach (var data in _tileData)
        {
            foreach (var tile in data.tiles)
            {
                _tileDataDict.Add(tile,data);
            }
        }
    }

    public Vector3Int MousePos2GridPos(Vector3 mousePosition)
    {
        return map.WorldToCell(Camera.main.ScreenToWorldPoint(mousePosition));
    }

    public String GetTileType(Vector3 mousePosition)
    {
        var currentTile = map.GetTile(MousePos2GridPos(mousePosition));
        return currentTile is null ? "" : _tileDataDict[currentTile].terrainType;
    }
}
