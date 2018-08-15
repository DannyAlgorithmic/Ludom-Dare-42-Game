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
    public MovementAction MoveAction;
    public SwapOccupiedTileAction TileSwapAction;

    private Queue<BaseAction> actionQueue;
    

    private void Awake()
    {
        selfTrans = transform;
        actionQueue = new Queue<BaseAction>();

        UpdateIndices(StartIndice);
        
    }

    private void Start()
    {
        StartingAction.TakeAction(this);
    }

    private void Update()
    {
        DragDirection.UpdateData();

        if (Input.GetMouseButtonUp(0) && Vector2.Distance(selfTrans.position, DragDirection.start ) <= 0.6f )
        {
            MoveAction.Direction = DragDirection.dir;
            MoveAction.TakeAction(this);
            TileSwapAction.TakeAction(this);
            // SwapAction.TakeAction(this);
        }
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

        actionQueue.Clear();
    }

    public void UpdateIndices(Vector2Int _indice)
    {
        prevIndice = currentIndice;
        currentIndice = _indice;
    }

}
