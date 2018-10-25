using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateCursor : MonoBehaviour {

    Handle_Cursor cursor;

    bool carrying;

	// Use this for initialization
	void Start () {
        cursor = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Handle_Cursor>();
        cursor.setMouse();
	}
	
	// Update is called once per frame
	void Update () {
        if (carrying)
        {
            cursor.setGrab();
        }
	}

    void OnMouseEnter()
    {
        cursor.setHand();
        
    }

    void OnMouseExit()
    {
        cursor.setMouse();
    }

    void OnMouseDown()
    {
        carrying = true;
    }

    void OnMouseUp()
    {
        carrying = false;
        cursor.setMouse();
    }
}
