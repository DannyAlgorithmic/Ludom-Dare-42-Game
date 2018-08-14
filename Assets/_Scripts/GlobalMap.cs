using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu (menuName = "Map")]
public class GlobalMap : ScriptableObject {

    public static Tile[,] Map {set; get;}
    public static Vector2Int MapBounds { set; get; }
    public static Vector2Int ClampToBounds(Vector2Int _oldIndice)
    {
        int x = Mathf.Clamp(_oldIndice.x, 0, MapBounds.x - 1), y = Mathf.Clamp(_oldIndice.y, 0, MapBounds.y - 1);
        return new Vector2Int(x, y);
    }

    public static void FillMap(Vector2 _originPos, Tile _prefab, TileData _neutralData)
    {
        float offset = 0.5f;

        for (int x = 0; x < MapBounds.x; x++)
        {
            for (int y = 0; y < MapBounds.y; y++)
            {
                Vector2 tilePos = _originPos + new Vector2(x - MapBounds.x / 2 + ((MapBounds.x % 2) == 0 ? offset : 0.0f), y - MapBounds.y / 2 + ((MapBounds.y % 2) == 0 ? offset : 0.0f));

                Tile tileObj = Instantiate(_prefab, tilePos, Quaternion.identity, null);
                tileObj.Indice = new Vector2Int(x, y);
                tileObj.Position = tilePos;
                tileObj.ResetTile();

                PlaceTile(new Vector2Int(x, y), tileObj);
            }
        }
    }

    public static void PlaceTile(Vector2Int _indice, Tile _tile)
    {
        Vector2Int clampedIndice = ClampToBounds(_indice);
        Map[clampedIndice.x, clampedIndice.y] = _tile;
    }

    public static Tile GetTile(Vector2Int _indice)
    {
        Vector2Int clampedIndice = ClampToBounds(_indice);
        return Map[clampedIndice.x, clampedIndice.y];
        
    }

    public static Vector2Int NearestIndice(Vector2 _mousePos)
    {
        float dist = Mathf.Infinity;
        Vector2Int output = Vector2Int.zero;

        foreach (Tile tile in Map)
        {
            float newDist = Vector2.Distance(_mousePos, tile.Position);

            if (newDist < dist)
            {
                dist = newDist;
                output = tile.Indice;
            }
        }

        return output;
    }

    public static bool IsEdge(Vector2Int _indice)
    {
        bool output = false;

        output = (_indice.x == 0 || _indice.x == MapBounds.x-1) || (_indice.y == 0 || _indice.y == MapBounds.y-1) ? true : false;

        return output;
    }

    public static bool WithinBounds(Vector2 _pos)
    {
        float x = _pos.x, y = _pos.y;
        return (x >= 0 || x <= MapBounds.x) && (y >= 0 || y <= MapBounds.y);
    }

    public static bool NullCheck(Vector2Int _indice)
    {
        // bool output = Map != null && Map[_indice.x, _indice.y] != null;
        return Map[_indice.x, _indice.y] != null;
    }

    public static void SetPointTile(TileData _pointData)
    {
        int x = Random.Range(0, MapBounds.x), y = Random.Range(0, MapBounds.y); ;
        Vector2Int randIndice = new Vector2Int(x, y);

        Tile tile = GetTile(randIndice);
        bool empySpace = tile.Data.type == TileType.NEUTRAL;

        if (empySpace == true)
        {
            tile.RefreshData(_pointData);
            tile.UpdateTile();
        }
        else
        {
            SetPointTile(_pointData);
        }
    }

}
