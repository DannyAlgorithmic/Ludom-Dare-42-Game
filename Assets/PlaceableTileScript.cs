using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;

public class PlaceableTileScript : MonoBehaviour, IBeginDragHandler, IDragHandler, IDropHandler, IEndDragHandler
{
    public TileData[] DataList;
    [Range(0, 10)]
    public float TileFloatMultiplier = 1;

    private TileData currentData;
    private Transform parent, self;
    private Image img;
    private bool isDragging = false;

    private void Awake()
    {
        self = transform;
        parent = self.parent;
        img = GetComponent<Image>();

        ReplaceData();
        UpdateImage();

    }

    private void Update()
    {
        if (isDragging == true)
        {
            UpdateTilePosition();
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        isDragging = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        
    }

    public void OnDrop(PointerEventData eventData)
    {
        Tile tile = GlobalMap.GetTile(IndiceSelector.Indice);

        if (tile.Data.type == TileType.NEUTRAL)
        {
            tile.RefreshData(currentData);
            tile.UpdateTile();

            TurnTimer.CurrentPlayer.UpdateMovePoints(tile.Data.Cost);
            
            ReplaceData();
            UpdateImage();
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        isDragging = false;
        self.position = parent.position;
    }

    private void UpdateTilePosition()
    {
        IndiceSelector.FetchInice();
        self.position = Vector2.Lerp(self.position, IndiceSelector.mousePos, TileFloatMultiplier * Time.deltaTime);
    }


    private void ReplaceData()
    {
        int rand = Random.Range(0, DataList.Length);
        currentData = DataList[rand];
    }

    private void UpdateImage()
    {
        img.sprite = currentData.sprite;
    }
}
