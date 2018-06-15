using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchController : MonoBehaviour {

    private Ray ray;
    private RaycastHit2D hit;
    private Vector3 touchPos;
    private Transform objectHit;
    private Vector3 oldPostObjectHit;

    private bool allowMovePieces;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButton(0))
        {
            touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            hit = Physics2D.Raycast(touchPos, Vector2.zero, 10, 1<<9);

            if(hit.collider != null && objectHit == null){
                objectHit = hit.transform.parent;
                oldPostObjectHit = objectHit.position;
                objectHit.transform.localScale = Vector3.one;
            }
            if (objectHit != null)
            {
                objectHit.transform.position = new Vector3(touchPos.x, touchPos.y + 5f, objectHit.transform.position.z);
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            if (objectHit != null)
            {
                objectHit.transform.localScale = Vector3.one * 0.8f;
                objectHit.position = oldPostObjectHit;
                InsertShapeMatrix newInsert = objectHit.GetComponentInChildren<BitController>().InsertValueToMatrix100();
                Debug.Log(objectHit.GetComponentInChildren<BitController>().name);
                if(newInsert != null)
                    MatrixManager.Instance().InsertShapeMatrix(newInsert);
                objectHit = null;
            }
        }
	}
}
