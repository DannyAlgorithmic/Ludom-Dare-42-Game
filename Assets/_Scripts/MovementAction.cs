using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Actions/Movement")]
public class MovementAction : BaseAction {
    public Vector2Int Direction;
    public override void TakeAction(PlayerController ctrl)
    {
        Tile tile = GlobalMap.GetTile( (ctrl.currentIndice + Direction) );

        if (GlobalMap.Map != null && tile != null && tile.Data.type == TileType.NEUTRAL || tile.Data.type == TileType.POINT)
        { ctrl.selfTrans.position = tile.Position; }

        Debug.Log( "Move Tile" );
    }
}
