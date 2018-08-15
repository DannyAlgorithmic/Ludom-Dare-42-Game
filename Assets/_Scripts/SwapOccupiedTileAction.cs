using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Actions/Swap Occupied Tile")]
public class SwapOccupiedTileAction : BaseAction {
    public override void TakeAction(PlayerController ctrl)
    { Swap(ctrl); }
    private void Swap(PlayerController _ctrl)
    {

        GlobalMap.ResetTile(_ctrl.prevIndice);
        GlobalMap.SetTileData(_ctrl.currentIndice, _ctrl.PlayerTileData);
        

    }
}
