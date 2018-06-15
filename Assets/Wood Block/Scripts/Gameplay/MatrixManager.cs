using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatrixManager : MonoBehaviour {
    private static MatrixManager _instance;
    [HideInInspector]
    public Transform[,] MatrixPosition;
    public int[,] ValueMatrix1010 = new int[10,10];

    public static MatrixManager Instance()
    {
        if(_instance == null)
        {
            _instance = FindObjectOfType<MatrixManager>();
        }
        return _instance;
    }
    private void Awake()
    {
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                ValueMatrix1010[i, j] = 0;
            }
        }
    }
    private void Start()
    {
        MatrixPosition = SpawnPositionMatrix.Instance.MatrixPosition;
    }

    private Vector2Int diffFromFirstBit;
    private string matrix;
    public void InsertShapeMatrix(InsertShapeMatrix insert)
    {
        Vector2Int firstBitShape = insert.FirstBitShape;
        Vector2Int firstBitIn1010 = insert.FirstBitIn1010;
        List<Vector2Int> ValueableList = insert.ValueableList;

        ValueMatrix1010[firstBitIn1010.x, firstBitIn1010.y] = 1;
        for (int i = 1; i < ValueableList.Count; i++)
        {
            diffFromFirstBit.x = ValueableList[i].x - ValueableList[0].x;
            diffFromFirstBit.y = ValueableList[i].y - ValueableList[0].y;
            diffFromFirstBit.x += firstBitIn1010.x;
            diffFromFirstBit.y += firstBitIn1010.y;
            ValueMatrix1010[diffFromFirstBit.x, diffFromFirstBit.y] = 1;
            diffFromFirstBit.x = 0;
            diffFromFirstBit.y = 0;
        }

        for(int i = 0; i < 10; i++)
        {
            for(int j = 0; j < 10; j++)
            {
                matrix += ValueMatrix1010[i, j];
            }
            matrix += "\n";
        }
        Debug.Log(matrix);
        matrix = "";
    }
    public void RemoveValueInMatrix()
    {
        for(int i = 0; i < 10; i++)
        {
            for(int j = 0; j < 10; j++)
            {
                ValueMatrix1010[i, j] = 0;
            }
        }
    }
    public void CheckCompletedRowNColumn()
    {

    }
}

public class InsertShapeMatrix
{
    public Vector2Int FirstBitShape;
    public Vector2Int FirstBitIn1010;
    public List<Vector2Int> ValueableList;
    public InsertShapeMatrix(Vector2Int firstBitShape, Vector2Int firstBitIn1010, List<Vector2Int> valueableList)
    {
        FirstBitShape = firstBitShape;
        FirstBitIn1010 = firstBitIn1010;
        ValueableList = valueableList;
    }
}
