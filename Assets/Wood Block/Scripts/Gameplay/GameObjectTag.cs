using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectTag : MonoBehaviour {
    private static GameObjectTag instance;

    [HideInInspector]
    public string TCells = "cells";
    [HideInInspector]
    public string TMatrixBit = "matrixBit";

    public static GameObjectTag Instance()
    {
        if (instance == null)
        {
            instance = FindObjectOfType<GameObjectTag>();
        }
        return instance;
    }
	
}
