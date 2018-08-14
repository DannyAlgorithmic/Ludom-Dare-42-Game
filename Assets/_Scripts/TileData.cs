using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TileData : ScriptableObject{
    public TileType type;
    public PlayerFilter filter;
    public Sprite sprite;

    public abstract void Act(PlayerController ctrl);
}


