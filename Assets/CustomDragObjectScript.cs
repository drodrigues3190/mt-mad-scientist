using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomDragObjectScript : MonoBehaviour {
    Vector3 dist;
    float posX;
    float posY;

    float distance = 5;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseDown()
    {
        dist = Camera.main.WorldToScreenPoint(transform.position);
        posX = Input.mousePosition.x - dist.x;
        posY = Input.mousePosition.y - dist.y;
    }

    private void OnMouseDrag()
    {
        Vector3 curPos = new Vector3(Input.mousePosition.x - posX, Input.mousePosition.y - posY, dist.z);
        Vector3 wordPos = Camera.main.ScreenToWorldPoint(curPos);
        transform.position = wordPos;
        //Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
        //Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition) * Time.deltaTime;
        //transform.position = objPosition;
    }
}
