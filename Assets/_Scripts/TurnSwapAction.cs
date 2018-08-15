using UnityEngine;

[CreateAssetMenu (menuName = "Actions/SwapTurns")]
public class TurnSwapAction : BaseAction {
    public override void TakeAction(PlayerController ctrl)
    {
        TurnTimer.SwitchPlayers(ctrl.PlayerTileData.filter);
    }
}
