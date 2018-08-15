using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

[CreateAssetMenu (menuName = "Actions/Reset Point Tile")]
public class ResetPointAction : BaseAction {
    public override void TakeAction(PlayerController ctrl)
    {
        SceneManager.LoadSceneAsync(0, LoadSceneMode.Single);
        // GlobalMap.SetPointTile();
    }
}
