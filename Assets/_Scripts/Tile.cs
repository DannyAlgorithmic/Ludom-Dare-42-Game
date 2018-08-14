using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour {

    public TileData DefaultData;
    // Tile Specific Data
    public Vector2Int Indice { set; get; }
    public Vector2 Position { set; get; }
    public TileData Data { set; get; }

    // Generic Object Data
    private SpriteRenderer sr;
    // private Transform tileTrans;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
       // tileTrans = transform;
    }

    private void OnEnable()
    {
        ResetTile();
    }

    public void ResetTile()
    {
        Data = DefaultData;
        UpdateTile();
    }

    public void RefreshData(TileData _data)
    {
        Data = _data;
    }

    public void UpdateTile()
    {
        if (Data != null)
        {
            sr.sprite = Data.sprite;
        }

        // Debug.Log("Tile Type: " + Data.type);
    }

}
