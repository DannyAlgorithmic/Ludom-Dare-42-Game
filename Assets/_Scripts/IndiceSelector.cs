using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndiceSelector : MonoBehaviour {

    public static Vector2Int Indice;
    Camera cam;
    Vector2 mousePos;

    private void Awake()
    {
        cam = Camera.main;
    }


    void Update () {

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        if ( Input.GetMouseButton(0) || Input.GetMouseButton(1) )
        {
            Indice = GlobalMap.NearestIndice(mousePos);
        }
	}

}
