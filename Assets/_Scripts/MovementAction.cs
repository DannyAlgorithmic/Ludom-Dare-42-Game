using UnityEngine;

[CreateAssetMenu(menuName = "Actions/Movement")]
public class MovementAction : BaseAction {
    public Vector2Int Direction;
    public override void TakeAction(PlayerController _ctrl)
    {
        Tile tile = GlobalMap.GetTile( (_ctrl.currentIndice + Direction) );

        if (GlobalMap.Map != null && tile != null)
        {
            TileType type = tile.Data.type;
            PlayerFilter filter = PlayerFilter.NONE;
            if ( type == TileType.NEUTRAL || type == TileType.POINT || type == TileType.MOVE || type == TileType.HEALTH)
            {
                JumpToTile(_ctrl, tile);
                // Debug.Log("Tried to move to type: " + type);
            }
            else if ( type == TileType.PLAYER && DirectionalityCheck.Check(Direction) == Directionality.Diagonal && GlobalMap.IsEdge(tile.Indice) == false)
            {
                tile = GlobalMap.GetTile(_ctrl.currentIndice + Direction * 2 );
                type = tile.Data.type;
                filter = tile.Data.filter;

                if (type == TileType.NEUTRAL || type == TileType.POINT || type == TileType.MOVE || type == TileType.HEALTH)
                { JumpToTile(_ctrl, tile); }
                else if ( type == TileType.BLOCKING && filter == PlayerFilter.BOTH )
                {
                    // Debug.Log("Blocked");
                }
                else
                {
                    if (filter != _ctrl.PlayerTileData.filter)
                    {
                        JumpToTile(_ctrl, tile);
                        // Debug.Log("Tried to jump player of type: " + type + " moving: " + DirectionalityCheck.Check(Direction));
                    }
                    
                }
            }
            else
            {
                Debug.Log("Blocked");
            }
        }
    }

    private void JumpToTile(PlayerController _ctrl, Tile _tile)
    {
        _ctrl.selfTrans.position = _tile.Position;
        _ctrl.UpdateIndices(_tile.Indice);
        _ctrl.AddActions(_tile.Data.ActionList);
        _ctrl.StepThroughActions();
    }
       
}
