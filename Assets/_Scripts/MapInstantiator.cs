using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapInstantiator : MonoBehaviour {
    public Vector2Int MapSize;
    public Tile TilePrefab;
    public TileData DefaultData;

    // private GlobalMap Map;

    private Transform selftTrans;

    private void Awake()
    {
        // Map = GetComponent<GlobalMap>();

        selftTrans = transform;

        CreateMap();
    }

    private void CreateMap()
    {
        GlobalMap.MapBounds = MapSize;
        GlobalMap.Map = new Tile[MapSize.x, MapSize.y];

        GlobalMap.FillMap(selftTrans.position, TilePrefab, DefaultData);
    }

}
