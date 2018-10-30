using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorControllerScript : MonoBehaviour {

    public float movSpeed;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(movSpeed * Input.GetAxisRaw("Left Stick X Axis") * Time.deltaTime, movSpeed * Input.GetAxisRaw("Right Stick Y Axis") * Time.deltaTime, movSpeed * Input.GetAxisRaw("Left Stick Y Axis") * Time.deltaTime);
	}
}
