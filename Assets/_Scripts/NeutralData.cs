using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "MapTile/Neutral")]
public class NeutralData : TileData
{
    public override void Act(PlayerController ctrl)
    {
        // Debug.Log("No action Available");
    }
}
