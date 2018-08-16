using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Tile Data")]
public class TileData : ScriptableObject{

    [Range(1, 10)]
    public int Cost = 0;
    public TileType type;
    public PlayerFilter filter;
    public Sprite sprite;
    public BaseAction[] ActionList;
}


