using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPositionMatrix : MonoBehaviour {
    public static SpawnPositionMatrix Instance;
    public Transform[,] MatrixPosition = new Transform[10,10];

    [SerializeField] Transform matrixParentTransform;
    public float distanceSpawn;
    [SerializeField] Sprite SquareImg;


    [ContextMenu("Spawn Position Matrix")]
    private void Awake()
    {
        if (Instance == null)
            Instance = this;

        if (matrixParentTransform.childCount == 0)
        {
            Vector3 startScreenPoint = Camera.main.ScreenToWorldPoint(Vector3.zero);
            Vector3 endScreenPoint = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0));
            distanceSpawn = Vector3.Distance(startScreenPoint, endScreenPoint) / 10;

            SpawnMatrix();
        }
    }

    Transform posObject;
	private void SpawnMatrix()
    {
        float xDiffValue = 0;
        float yDiffValue = 0;
        string namePos;
        for (int i = 0; i < 10; i++)
        {
            yDiffValue = (4.5f -i);
            for (int j = 0; j < 10; j++)
            {
                xDiffValue = (j - 4.5f);
                namePos = i.ToString() + " : " + j.ToString();
                posObject = MatrixPosition[i, j];
                posObject = new GameObject(namePos).transform;
                posObject.SetParent(matrixParentTransform);
                posObject.position = new Vector3(xDiffValue * distanceSpawn, yDiffValue * distanceSpawn, 0);
                posObject.tag = GameObjectTag.Instance().TCells;
                posObject.gameObject.AddComponent<SpriteRenderer>().sprite = SquareImg;
                posObject.GetComponent<SpriteRenderer>().color = new Color(0.1f, 0.3f, 0.5f, 1);
                posObject.gameObject.AddComponent<BoxCollider2D>().isTrigger = true;
                posObject.gameObject.AddComponent<Rigidbody2D>().gravityScale = 0;
                MatrixPosition[i, j] = posObject;
            }
        }
    }
	
}
