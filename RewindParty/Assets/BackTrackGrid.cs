using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackTrackGrid : MonoBehaviour
{
    [SerializeField] private Vector2 gridSize;

    private static Grid grid;

    private void Awake()
    {
        grid = GetComponent<Grid>();   
    }

    public static Vector2 GetNearestPointOnGrid(Vector2 position)
    {
        //We find nearest point where position can attach to.
        int xCount = Mathf.RoundToInt(position.x / grid.cellSize.x);
        int yCount = Mathf.RoundToInt(position.y / grid.cellSize.y);

        Vector3 result = new Vector2(xCount * grid.cellSize.x, yCount * grid.cellSize.y);

        return result;
    }
}
