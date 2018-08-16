using UnityEngine;

public class IndiceSelector : MonoBehaviour {

    public static Vector2Int Indice { set; get; }
    public static Camera cam { set; get; }
    public static Vector2 mousePos { set; get; }

    private void Awake()
    {
        cam = Camera.main;
    }


    void Update () {

        FetchInice();
	}


    public static void FetchInice()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButton(0) || Input.GetMouseButton(1))
        {
            Indice = GlobalMap.NearestIndice(mousePos);
        }
    }
}
