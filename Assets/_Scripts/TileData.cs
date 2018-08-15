using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "TileData")]
public class TileData : ScriptableObject{

    public TileType type;
    public PlayerFilter filter;
    public Sprite sprite;
    public BaseAction[] ActionList;

    public void FetchActions(PlayerController ctrl)
    {
        if (ActionList != null && ActionList.Length > 0)
        {
            ctrl.AddActions(ActionList);
        }
    }

}


