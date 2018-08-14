using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSwitch : MonoBehaviour {

    public TileData ReplaceData;
    public Vector2Int SwitchIndice;
    private Tile tile;


    void Update () {

        if (Input.GetKeyDown(KeyCode.Space) && GlobalMap.Map != null)
        {
            tile = GlobalMap.GetTile(SwitchIndice);
            if (tile != null)
            {
                tile.RefreshData(ReplaceData);
                tile.UpdateTile();
            }

            Debug.Log("Tile type: " + tile.Data.type);
        }

        if (Input.GetKeyUp(KeyCode.Space) && GlobalMap.Map != null && tile != null)
        {
            tile.ResetTile();
            tile = null;
        }
    }
}
