using UnityEngine;

public class DirectionalityCheck
{

    public static Directionality Check(Vector2 currentIndice, Vector2 targetIndice)
    {
        Directionality output = Directionality.Orthogonal;

        Vector2 newVect = targetIndice - currentIndice;

        float vecResult = Mathf.Abs(newVect.x) + Mathf.Abs(newVect.y);

        if (vecResult == 1)
        { output = Directionality.Orthogonal; }
        else if (vecResult == 2)
        { output = Directionality.Diagonal; }

        return output;
    }

    public static Directionality Check(Vector2 _dir)
    {
        Directionality output = Directionality.Orthogonal;

        float vecResult = Mathf.Abs(_dir.x) + Mathf.Abs(_dir.y);

        if (vecResult == 1)
        { output = Directionality.Orthogonal; }
        else if (vecResult == 2)
        { output = Directionality.Diagonal; }

        return output;
    }

    public static Directionality Check(Vector2Int _dir)
    {
        Directionality output = Directionality.Orthogonal;

        float vecResult = Mathf.Abs(_dir.x) + Mathf.Abs(_dir.y);

        if (vecResult == 1)
        { output = Directionality.Orthogonal; }
        else if (vecResult == 2)
        { output = Directionality.Diagonal; }

        return output;
    }

}
