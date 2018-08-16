using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public TileData PlayerTileData;
    public Vector2Int StartIndice;
    public BaseAction StartingAction;
    public MovementAction MoveAction;
    public SwapOccupiedTileAction TileSwapAction;
    [Range(1, 20)]
    public int MaxMovePoints = 3, OrthogonalCost = 1, DiagonalCost = 2;

    [HideInInspector]
    public Vector2Int currentIndice = Vector2Int.zero, prevIndice = Vector2Int.zero;
    [HideInInspector]
    public Transform selfTrans;

    public AudioSource soundSource;

    private Queue<BaseAction> actionQueue;
    private static int movePoints = 1;

    private void Awake()
    {
        movePoints = MaxMovePoints;
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
            if (movePoints >= 1)
            {
                MoveAction.Direction = DragDirection.dir;
                Directionality currentDir = DirectionalityCheck.Check(DragDirection.dir);
                if (movePoints > 1)
                {
                    movePoints = (currentDir == Directionality.Orthogonal) ? movePoints-= OrthogonalCost : movePoints -= DiagonalCost;
                    movePoints = Mathf.Clamp(movePoints, 1, MaxMovePoints);

                    MoveAction.TakeAction(this);
                    TileSwapAction.TakeAction(this);
                    movePoints = MaxMovePoints;
                }
                else if (currentDir == Directionality.Orthogonal)
                {
                    movePoints = movePoints -= OrthogonalCost;
                    movePoints = Mathf.Clamp(movePoints, 1, MaxMovePoints);

                    MoveAction.TakeAction(this);
                    TileSwapAction.TakeAction(this);
                    movePoints = MaxMovePoints;
                }
            }
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

    public void UpdateMovePoints(int count)
    {
        movePoints -= count;
        movePoints = Mathf.Clamp(movePoints, 1, MaxMovePoints);
    }

}
