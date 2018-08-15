using UnityEngine;

public class DragDirection : MonoBehaviour {

    private static Camera cam;
    public static Vector2 start, current, end;
    public static Vector2Int dir;
    public static float dist = 0;

    // For Testing Purposes
    private static LineRenderer lr;

    private void Awake()
    {
        cam = Camera.main;
        lr = GetComponent<LineRenderer>();
    }

    public static void UpdateLine()
    {
        if (Input.GetMouseButtonDown(0))
        {
            lr.enabled = true;
            lr.positionCount = 2;

            lr.SetPosition(0, start);
            lr.SetPosition(1, start);
        }

        if (Input.GetMouseButton(0))
        {
            lr.SetPosition(1, start + (new Vector2(dir.x, dir.y) * dist));
        }

        if (Input.GetMouseButtonUp(0))
        {
            lr.positionCount = 0;
            lr.enabled = false;
        }
    } 

    public static void ResetLine()
    {
        lr.enabled = false;
        lr.positionCount = 0;
    }

    public static void UpdateData(Vector2 _pos)
    {

        if (Input.GetMouseButtonDown(0))
        {
            start = _pos;
            dist = 0;
        }

        if (Input.GetMouseButton(0))
        {
            current = cam.ScreenToWorldPoint(Input.mousePosition);
            dist = (current - start).magnitude;
            dir = CalculateDirection(start, current);
            // Debug.Log("Direction: " + dir + "Distance: " + dist);
        }

        if (Input.GetMouseButtonUp(0))
        {
            end = current;
            dist = (current - start).magnitude;
            dir = CalculateDirection(start, current);
        }
    }

    public static void UpdateData()
    {

        if (Input.GetMouseButtonDown(0))
        {
            start = cam.ScreenToWorldPoint(Input.mousePosition);
            dist = 0;
        }

        if (Input.GetMouseButton(0))
        {
            current = cam.ScreenToWorldPoint(Input.mousePosition);
            dist = (current - start).magnitude;
            dir = CalculateDirection(start, current);
            // Debug.Log("Direction: " + dir + "Distance: " + dist);
        }

        if (Input.GetMouseButtonUp(0))
        {
            end = current;
            dist = (current - start).magnitude;
            dir = CalculateDirection(start, current);
        }
    }

    private static Vector2Int CalculateDirection(Vector2 start, Vector2 current)
    {
        Vector2 heading = (current - start).normalized;
        int x = Mathf.RoundToInt(heading.x), y = Mathf.RoundToInt(heading.y);
        return new Vector2Int(x, y);
    }

}
