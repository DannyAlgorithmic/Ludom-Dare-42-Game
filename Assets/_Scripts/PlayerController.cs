using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public TileData PlayerTileData;

    public Vector2Int StartIndice;
    [HideInInspector]
    public Vector2Int currentIndice = Vector2Int.zero,
                      prevIndice = Vector2Int.zero;
    [HideInInspector]
    public Transform selfTrans;

    public BaseAction StartingAction;

    private Queue<BaseAction> actionQueue;
    

    private void Awake()
    {
        selfTrans = transform;
        actionQueue = new Queue<BaseAction>();

        UpdateIndices();
        StartingAction.TakeAction(this);
    }


    public void AddActions(BaseAction[] _actions)
    {
        if (actionQueue!= null && _actions != null && _actions.Length > 0)
        {
            foreach (BaseAction action in _actions)
            {
                if (action != null)
                { actionQueue.Enqueue(action); }
            }
        }
    }

    public void StepThroughActions()
    {
        while (actionQueue != null && actionQueue.Count > 0)
        {
            actionQueue.Dequeue().TakeAction(this);
        }
    }

    public void UpdateIndices()
    {
        currentIndice = StartIndice;
        prevIndice = currentIndice;
    }

}
