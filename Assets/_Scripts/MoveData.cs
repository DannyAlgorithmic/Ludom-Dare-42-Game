using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "MapTile/Move")]
public class MoveData : TileData {
    public BaseAction MoveAction;

    public override void Act(PlayerController ctrl)
    {
        MoveAction.TakeAction(ctrl);
    }
}
