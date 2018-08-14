using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Actions/Movement")]
public class MovementAction : BaseAction {
    public Vector2Int Direction;
    public override void TakeAction(PlayerController ctrl)
    {
        Tile tile = GlobalMap.GetTile(ctrl.currentIndice + Direction);

        ctrl.prevIndice = ctrl.currentIndice;
        ctrl.currentIndice = tile.Indice;

        ctrl.selfTrans.position = tile.Position;

        tile.RefreshData(ctrl.PlayerTileData);
        tile.UpdateTile();

        GlobalMap.GetTile(ctrl.prevIndice).ResetTile();
        TurnTimer.SwitchPlayers(ctrl.PlayerTileData.filter);

        Debug.Log("Move Tile move " +ctrl.name + " to indice: " + ( tile.Indice ) );
    }
}
