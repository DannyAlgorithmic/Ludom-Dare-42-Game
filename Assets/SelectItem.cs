using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectItem : MonoBehaviour {

    public TileData ReplaceData;

    public TileData LeftItem, MidItem, RightItem;

    private void Update()
    {
        /*
        if(Input.GetKeyDown(KeyCode.A)){
            ReplaceData = LeftItem.Data;
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            ReplaceData = MidItem.Data;
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            ReplaceData = RightItem.Data;
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            IndiceSelector.FetchInice();

            // Debug.Log("Trying to select data");

            if (Input.GetMouseButtonDown(1))
            {
                ReplaceTileData();
                // Debug.Log("Trying to replace data");
            }
        }
        */
    }


    public void ReplaceTileData(TileData data)
    {
        IndiceSelector.FetchInice();
        Tile tile = GlobalMap.GetTile(IndiceSelector.Indice);
        tile.RefreshData(data);
        tile.UpdateTile();

        // Debug.Log("Pressed: " + txt);
    }
}
