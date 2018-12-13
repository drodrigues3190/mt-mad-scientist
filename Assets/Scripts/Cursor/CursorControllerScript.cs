using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XInputDotNetPure;

public class CursorControllerScript : MonoBehaviour {

    public float movSpeed;


    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        OnButtonX();
        transform.Translate(movSpeed * Input.GetAxisRaw("Left Stick X Axis") * Time.deltaTime, movSpeed * Input.GetAxisRaw("Right Stick Y Axis") * Time.deltaTime, movSpeed * Input.GetAxisRaw("Left Stick Y Axis") * Time.deltaTime);
	}

    /// <summary>
    /// Reset the cursor to the original position
    /// </summary>
    void OnButtonX()
    {
        if (Input.GetButton("XButton"))
            transform.position = new Vector3(0.0f, 2.5f, 0.0f);
    }
}
