using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Range(1, 6)]
    public int MaxHealth = 3, MaxMovePoints = 3;

    public TileData PlayerTileData, StarData;
    public Vector2Int StartIndice;
    
    [HideInInspector]
    public Transform selfTrans;
    [HideInInspector]
    public Vector2Int prevIndice;
    [HideInInspector]
    public Vector2Int currentIndice;

    private int Score = 0, maxScore = 3, currentHealth = 0, currentMovePoint = 0;
    bool canMove = false;


    void Start () {
        currentHealth = MaxHealth;
        currentMovePoint = MaxMovePoints;

        currentIndice = StartIndice;
        prevIndice = currentIndice;

        selfTrans = transform;

        MoveToTile(GlobalMap.GetTile(currentIndice));

        if (PlayerTileData.filter == PlayerFilter.PLAYER_ONE)
        {
            GlobalMap.SetPointTile(StarData);
        }
    }
	
	
	void Update () {
        // Abstract away a lot of this!
        Turn();
	}


    private void Turn()
    {
        if (Input.GetMouseButtonUp(0) && Vector2.Distance(currentIndice, IndiceSelector.Indice) < 1.5f)
        {
            

            // Debug.Log(gameObject.name);

            Tile tile = GlobalMap.GetTile(IndiceSelector.Indice);
            switch (tile.Data.type)
            {
                case TileType.NEUTRAL:
                    MoveToTile(tile);
                    ResetPrevTile(prevIndice);
                    // Debug.Log("Moved!");
                    break;
                case TileType.BLOCKING:
                    // Debug.Log("Blocked!");
                    break;
                case TileType.HEALTH:
                    MoveToTile(tile);
                    ResetPrevTile(prevIndice);

                    // Debug.Log("Picked up health!");
                    break;
                case TileType.POINT:


                    if (Score < maxScore)
                    {
                        Score++;
                    }
                    else
                    {
                        SceneManager.LoadSceneAsync(0, LoadSceneMode.Single);
                    }

                    MoveToTile(tile);
                    ResetPrevTile(prevIndice);
                    // Debug.Log("Picked up POINT!");
                    break;
                case TileType.MOVE:
                    // Debug.Log("Moved Extra Spaces!");
                    break;
                case TileType.PLAYER:
                    if (PlayerTileData.filter != tile.Data.filter)
                    {
                        if (DirectionalityCheck.Check(currentIndice, IndiceSelector.Indice) == Directionality.Orthogonal)
                        { /* Debug.Log("Blocked by another player!");*/ }
                        else if (GlobalMap.IsEdge(IndiceSelector.Indice) == false)
                        {
                            tile = GlobalMap.GetTile(IndiceSelector.Indice + (IndiceSelector.Indice - currentIndice));
                            if (tile.Data.type != TileType.BLOCKING)
                            {
                                if (tile.Data.type == TileType.POINT)
                                {
                                    
                                    if (Score < maxScore)
                                    {
                                        Score++;
                                    }
                                    else
                                    {
                                        SceneManager.LoadSceneAsync(0, LoadSceneMode.Single);
                                    }
                                }

                                MoveToTile(tile);
                                ResetPrevTile(prevIndice);
                                // Debug.Log("Jumped over another player!");
                            }
                            else
                            {
                                // Debug.Log("Blocked!");
                            }

                            
                            
                        }
                        else
                        { /* Debug.Log("Cannot jump a player if they are on the edge!"); */ }
                    }
                    else
                    { /* Debug.Log("Tried to move to your own tile!");*/ }
                    break;
                default:
                    MoveToTile(tile);
                    ResetPrevTile(prevIndice);
                    break;
            }
            
        }

    }


    private void MoveToTile(Tile _tile)
    {
        prevIndice = currentIndice;


        selfTrans.position = _tile.Position;
        currentIndice = _tile.Indice;
        _tile.Data.Act(this);

        _tile.RefreshData(PlayerTileData);
        _tile.UpdateTile();
    }

    private void ResetPrevTile(Vector2Int _indice)
    {
        GlobalMap.GetTile(_indice).ResetTile();
        TurnTimer.SwitchPlayers(PlayerTileData.filter);
    }
}
