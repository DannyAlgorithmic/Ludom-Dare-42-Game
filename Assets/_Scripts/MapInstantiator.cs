using UnityEngine;

public class MapInstantiator : MonoBehaviour {
    public Vector2Int MapSize;
    public Tile TilePrefab;
    public TileData DefaultData, PointData, HealthData;

    private Transform selftTrans;

    private void Awake()
    {
        selftTrans = transform;
        CreateMap();
    }

    private void CreateMap()
    {
        GlobalMap.PointData = PointData;
        GlobalMap.HealthData = HealthData;
        GlobalMap.MapBounds = MapSize;
        GlobalMap.Map = new Tile[MapSize.x, MapSize.y];

        GlobalMap.FillMap(selftTrans.position, TilePrefab, DefaultData);

        GlobalMap.SetPointTile();
    }

}
