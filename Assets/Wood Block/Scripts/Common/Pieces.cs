using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName ="Pieces", menuName ="Piece/New Pieces")]
public class Pieces : ScriptableObject{

    public const char piece1 = '.';
    public const char piece2 = '-';
    public const char piece3 = 'i';
    public const char piece4 = '_';
    public const char piece5 = 'I';
    public const char piece6 = 'r';
    public const char piece7 = 'l';
    public const char piece8 = 'j';
    public const char piece9 = 't';
    public const char piece10 = 'h';
    public const char piece11 = 'O';
    public const char piece12 = 'H';
    public const char piece13 = 'V';
    public const char piece14 = 'J';
    public const char piece15 = 'T';
    public const char piece16 = 'R';
    public const char piece17 = 'o';
    public const char piece18 = 'v';
    public const char piece19 = 'L';

    public const string PiecesChain = ".-i_IrljthOHVJTRovL";

    public const int RowMatrixShape = 5;
    public const int ColumnMatrixShape = 5;

    public List<int[,]> GetPiecesList()
    {
        List<int[,]> piecesList = new List<int[,]>();
        piecesList.Add(Piece1Shape());
        piecesList.Add(Piece2Shape());
        piecesList.Add(Piece3Shape());
        piecesList.Add(Piece4Shape());
        piecesList.Add(Piece5Shape());
        piecesList.Add(Piece6Shape());
        piecesList.Add(Piece7Shape());
        piecesList.Add(Piece8Shape());
        piecesList.Add(Piece9Shape());
        piecesList.Add(Piece10Shape());
        piecesList.Add(Piece11Shape());
        piecesList.Add(Piece12Shape());
        piecesList.Add(Piece13Shape());
        piecesList.Add(Piece14Shape());
        piecesList.Add(Piece15Shape());
        piecesList.Add(Piece16Shape());
        piecesList.Add(Piece17Shape());
        piecesList.Add(Piece18Shape());
        piecesList.Add(Piece19Shape());
        return piecesList;
    }

    public int[,] Piece1Shape()
    {
        return new int[5, 5]
        {
            { 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0 },
            { 0, 0, 1, 0, 0 },
            { 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0 }
        };

    }
    public int[,] Piece2Shape()
    {
        return new int[5, 5]
        {
            { 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0 },
            { 0, 0, 1, 1, 0 },
            { 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0 }
        };

    }
    public int[,] Piece3Shape()
    {
        return new int[5, 5]
        {
            { 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0 },
            { 0, 0, 1, 0, 0 },
            { 0, 0, 1, 0, 0 },
            { 0, 0, 0, 0, 0 }
        };

    }
    public int[,] Piece4Shape()
    {
        return new int[5, 5]
        {
            { 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0 },
            { 0, 1, 1, 1, 0 },
            { 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0 }
        };

    }
    public int[,] Piece5Shape()
    {
        return new int[5, 5]
        {
            { 0, 0, 0, 0, 0 },
            { 0, 0, 1, 0, 0 },
            { 0, 0, 1, 0, 0 },
            { 0, 0, 1, 0, 0 },
            { 0, 0, 0, 0, 0 }
        };

    }
    public int[,] Piece6Shape()
    {
        return new int[5, 5]
        {
            { 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0 },
            { 0, 0, 1, 1, 0 },
            { 0, 0, 1, 0, 0 },
            { 0, 0, 0, 0, 0 }
        };

    }
    public int[,] Piece7Shape()
    {
        return new int[5, 5]
        {
            { 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0 },
            { 0, 0, 1, 0, 0 },
            { 0, 0, 1, 1, 0 },
            { 0, 0, 0, 0, 0 }
        };

    }
    public int[,] Piece8Shape()
    {
        return new int[5, 5]
        {
            { 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0 },
            { 0, 0, 0, 1, 0 },
            { 0, 0, 1, 1, 0 },
            { 0, 0, 0, 0, 0 }
        };

    }
    public int[,] Piece9Shape()
    {
        return new int[5, 5]
        {
            { 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0 },
            { 0, 0, 1, 1, 0 },
            { 0, 0, 0, 1, 0 },
            { 0, 0, 0, 0, 0 }
        };

    }
    public int[,] Piece10Shape()
    {
        return new int[5, 5]
        {
            { 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0 },
            { 0, 1, 1, 1, 1 },
            { 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0 }
        };

    }
    public int[,] Piece11Shape()
    {
        return new int[5, 5]
        {
            { 0, 0, 0, 0, 0 },
            { 0, 1, 1, 1, 0 },
            { 0, 1, 1, 1, 0 },
            { 0, 1, 1, 1, 0 },
            { 0, 0, 0, 0, 0 }
        };

    }
    public int[,] Piece12Shape()
    {
        return new int[5, 5]
        {
            { 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0 },
            { 1, 1, 1, 1, 1 },
            { 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0 }
        };

    }
    public int[,] Piece13Shape()
    {
        return new int[5, 5]
        {
            { 0, 0, 1, 0, 0 },
            { 0, 0, 1, 0, 0 },
            { 0, 0, 1, 0, 0 },
            { 0, 0, 1, 0, 0 },
            { 0, 0, 1, 0, 0 }
        };

    }
    public int[,] Piece14Shape()
    {
        return new int[5, 5]
        {
            { 0, 0, 0, 0, 0 },
            { 0, 0, 0, 1, 0 },
            { 0, 0, 0, 1, 0 },
            { 0, 1, 1, 1, 0 },
            { 0, 0, 0, 0, 0 }
        };

    }
    public int[,] Piece15Shape()
    {
        return new int[5, 5]
        {
            { 0, 0, 0, 0, 0 },
            { 0, 1, 1, 1, 0 },
            { 0, 0, 0, 1, 0 },
            { 0, 0, 0, 1, 0 },
            { 0, 0, 0, 0, 0 }
        };

    }
    public int[,] Piece16Shape()
    {
        return new int[5, 5]
        {
            { 0, 0, 0, 0, 0 },
            { 0, 1, 1, 1, 0 },
            { 0, 1, 0, 0, 0 },
            { 0, 1, 0, 0, 0 },
            { 0, 0, 0, 0, 0 }
        };

    }
    public int[,] Piece17Shape()
    {
        return new int[5, 5]
        {
            { 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0 },
            { 0, 0, 1, 1, 0 },
            { 0, 0, 1, 1, 0 },
            { 0, 0, 0, 0, 0 }
        };

    }
    public int[,] Piece18Shape()
    {
        return new int[5, 5]
        {
            { 0, 0, 0, 0, 0 },
            { 0, 0, 1, 0, 0 },
            { 0, 0, 1, 0, 0 },
            { 0, 0, 1, 0, 0 },
            { 0, 0, 1, 0, 0 }
        };

    }
    public int[,] Piece19Shape()
    {
        return new int[5, 5]
        {
            { 0, 0, 0, 0, 0 },
            { 0, 1, 0, 0, 0 },
            { 0, 1, 0, 0, 0 },
            { 0, 1, 1, 1, 0 },
            { 0, 0, 0, 0, 0 }
        };

    }
}
