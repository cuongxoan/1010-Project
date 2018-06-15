using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BitController : MonoBehaviour {
    public int[,] MyMatrix;
    public Transform[,] MatrixPosition;

    private List<Vector2Int> ValueableList = new List<Vector2Int>();
    private int[,] valueMatrix1010;
    private Color originColorBit;
    private float distanceCollision;
    private float diagonalScale;

    private Color colorInsert = new Color(0.4f, 1, 1, 1);
    private Color colorOut = new Color(0.1f, 0.3f, 0.5f, 1);

    private void Start()
    {
        diagonalScale = Mathf.Sqrt(transform.lossyScale.x* transform.lossyScale.x + transform.lossyScale.y * transform.lossyScale.y)*0.4f;
        MatrixPosition = SpawnPositionMatrix.Instance.MatrixPosition;

        GetFirstBitPosition();
        UpdateValueMatrix();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == GameObjectTag.Instance().TCells)
        {
            originColorBit = other.gameObject.GetComponent<SpriteRenderer>().color;
        }
    }
    private List<Transform> objectIsTriggring;
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.transform.tag == GameObjectTag.Instance().TCells)
        {
            distanceCollision = Vector3.Distance(transform.position, other.transform.position);
            if(distanceCollision < diagonalScale)
            {
                RemoveMyBitsToMatrixPos();
                GetFirstBitPosInMatrix1010(other.transform);
                InsertMyBitsToMatrixPos();
            }
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.transform.tag == GameObjectTag.Instance().TCells)
        {
            RemoveMyBitsToMatrixPos();
        }
    }

    private Vector2Int diffFromFirstBit;
    private bool allowInsertValueTo1010;
    private void InsertMyBitsToMatrixPos()
    {
        if(valueMatrix1010[firstBitIn1010.x, firstBitIn1010.y] == 1)
        {
            allowInsertValueTo1010 = false;
            return;
        }
        for (int i = 1; i < ValueableList.Count; i++)
        {
            diffFromFirstBit.x = ValueableList[i].x - ValueableList[0].x;
            diffFromFirstBit.y = ValueableList[i].y - ValueableList[0].y;
            diffFromFirstBit.x += firstBitIn1010.x;
            diffFromFirstBit.y += firstBitIn1010.y;
            if ((diffFromFirstBit.x > 9 || diffFromFirstBit.y > 9) || valueMatrix1010[diffFromFirstBit.x, diffFromFirstBit.y] == 1)
            {
                allowInsertValueTo1010 = false;
                return;
            }
            diffFromFirstBit.x = 0;
            diffFromFirstBit.y = 0;
        }
        allowInsertValueTo1010 = true;
        Debug.Log("true");
        MatrixPosition[firstBitIn1010.x, firstBitIn1010.y].GetComponent<SpriteRenderer>().color = colorInsert;
        for (int i = 1; i < ValueableList.Count; i++)
        {
            diffFromFirstBit.x = ValueableList[i].x - ValueableList[0].x;
            diffFromFirstBit.y = ValueableList[i].y - ValueableList[0].y;
            diffFromFirstBit.x += firstBitIn1010.x;
            diffFromFirstBit.y += firstBitIn1010.y;
            if (diffFromFirstBit.x > 9 || diffFromFirstBit.y > 9)
            {
                Debug.Log(">10");
            }
            MatrixPosition[diffFromFirstBit.x, diffFromFirstBit.y].GetComponent<SpriteRenderer>().color = colorInsert;
            diffFromFirstBit.x = 0;
            diffFromFirstBit.y = 0;
        }
        
    }

    
    public InsertShapeMatrix InsertValueToMatrix100()
    {

        if (allowInsertValueTo1010)
        {
            allowInsertValueTo1010 = false;
            UpdateValueMatrix();
            MatrixPosition[firstBitIn1010.x, firstBitIn1010.y].GetComponent<SpriteRenderer>().color = colorInsert;

            for (int i = 1; i < ValueableList.Count; i++)
            {
                diffFromFirstBit.x = ValueableList[i].x - ValueableList[0].x;
                diffFromFirstBit.y = ValueableList[i].y - ValueableList[0].y;
                diffFromFirstBit.x += firstBitIn1010.x;
                diffFromFirstBit.y += firstBitIn1010.y;
                MatrixPosition[diffFromFirstBit.x, diffFromFirstBit.y].GetComponent<SpriteRenderer>().color = colorInsert;
                diffFromFirstBit.x = 0;
                diffFromFirstBit.y = 0;
            }
            return new InsertShapeMatrix(firstBitPosition, firstBitIn1010, ValueableList);
        }
        return null;
    }
    private void RemoveMyBitsToMatrixPos()
    {
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                if(valueMatrix1010[i,j] == 0)
                    MatrixPosition[i, j].GetComponent<SpriteRenderer>().color = colorOut;                
            }
        }
    }

    private Vector2Int firstBitPosition;
    private bool isFirst;
    private void GetFirstBitPosition()
    {
        for (int i = 0; i < MyMatrix.GetLength(0); i++)
        {
            for (int j = 0; j < MyMatrix.GetLength(1); j++)
            {

                if (MyMatrix[i, j] == 1)
                {
                    if (!isFirst)
                    {
                        isFirst = true;
                        firstBitPosition.x = i;
                        firstBitPosition.y = j;
                    }
                    ValueableList.Add(new Vector2Int( i, j));
                }
            }
        }
    }
    private Vector2Int firstBitIn1010;
    private void GetFirstBitPosInMatrix1010(Transform other)
    {
        for(int i = 0; i < 10; i++)
        {
            for(int j = 0; j < 10; j++)
            {
                if (MatrixPosition[i,j].Equals(other))
                {
                    firstBitIn1010.x = i;
                    firstBitIn1010.y = j;
                    return;
                }
            }
        }
    }
    private void UpdateValueMatrix()
    {
        valueMatrix1010 = MatrixManager.Instance().ValueMatrix1010;
    }
   
}
