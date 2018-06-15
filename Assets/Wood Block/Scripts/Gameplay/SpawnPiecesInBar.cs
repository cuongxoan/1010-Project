using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPiecesInBar : MonoBehaviour {
    [SerializeField] string PiecesArray;
    [SerializeField] Pieces Pieces;
    [SerializeField] Sprite SquareImg;
    
    private float distanceSpawnBit;

    private string piecesChain;
    public int piecesNumShow = 3;

    private Transform mytransform;

    private List<int[,]> pieceMatrixList;


	
    private void AssignVariable()
    {
        piecesChain = Pieces.PiecesChain;
        pieceMatrixList = Pieces.GetPiecesList();
        distanceSpawnBit = SpawnPositionMatrix.Instance.distanceSpawn;
        mytransform = transform;
        distanceShowPieces = -distanceSpawnBit * 5;
    }

	private void Start () {

        AssignVariable();
        ReadPiecesArray();
        mytransform.localScale = Vector3.one * 0.8f;
    }
    


    private void ReadPiecesArray()
    {
        char letter;
        for (int i = 0; i < PiecesArray.Length; i++)
        {
            letter = PiecesArray[i];
            SpawnPiecesWithLetter(letter);
            if ((i + 1) % piecesNumShow == 0)
            {
                distanceShowPieces = -distanceSpawnBit * 5;
                break;
            }
        }
    }
    private void SpawnPiecesWithLetter(char letter)
    {
        for(int i = 0; i < piecesChain.Length; i++)
        {
            if(letter == piecesChain[i])
            {
                DrawAPiece(pieceMatrixList[i], letter);
            }
        }
    }
    private float distanceShowPieces;
    private bool addScriptToFirstBit;
    float xDiffValue = 0;
    float yDiffValue = 0;
    string nameBit;

    private void DrawAPiece(int[,] matrixOfPiece, char letter)
    {

        GameObject newPieces = new GameObject();
        newPieces.name = letter.ToString();
        newPieces.transform.position = Vector3.zero;
        newPieces.transform.SetParent(transform);        
        addScriptToFirstBit = false;

        for(int i = 0; i < matrixOfPiece.GetLength(0); i++)
        {
            yDiffValue = (1.5f - i);
            for(int j = 0; j < matrixOfPiece.GetLength(1); j++)
            {
                if (matrixOfPiece[i, j] == 1)
                {
                    xDiffValue = (j - 1.5f);
                    nameBit = i.ToString() + j.ToString();
                    GameObject bit = new GameObject();
                    bit.AddComponent<BoxCollider2D>();
                    bit.transform.SetParent(newPieces.transform);
                    bit.transform.position = new Vector3(xDiffValue * distanceSpawnBit, yDiffValue * distanceSpawnBit, 0);
                    bit.AddComponent<SpriteRenderer>().sprite = SquareImg;
                    bit.name = nameBit;
                    bit.layer = 9;
                    if (!addScriptToFirstBit)
                    {
                        addScriptToFirstBit = true;
                        bit.AddComponent<BitController>().MyMatrix = matrixOfPiece;
                    }
                }
            }
        }

        newPieces.transform.localPosition = new Vector3(distanceShowPieces, 0);
        distanceShowPieces += distanceSpawnBit * 5;
    }
}
