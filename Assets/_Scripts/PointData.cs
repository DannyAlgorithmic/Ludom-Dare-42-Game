using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "MapTile/Point")]
public class PointData : TileData
{
    public override void Act(PlayerController ctrl)
    {
        GlobalMap.SetPointTile(ctrl.StarData);
        // Debug.Log("Collected Point!");
    }
}
