using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Tile Data")]
public class TileData : ScriptableObject{

    public TileType type;
    public PlayerFilter filter;
    public Sprite sprite;
    public BaseAction[] ActionList;
}


