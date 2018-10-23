using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour {

    public Sprite defaultTexture;
    public Texture2D mouse;
    public Texture2D hand;
    public Texture2D grab;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;

    // Use this for initialization
    void Start () {
        setDefaultTexture();
    }
	
	// Update is called once per frame
	void Update () {
        //Vector3 pos = this.GetComponent<Camera>().ScreenToWorldPoint(Input.);

        //var target = GameObject.Find("Pointer");

        //target.transform.position = new Vector3(pos.x, pos.y, -10);

        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        transform.Translate(x, y, 0);
    }

    // Sets the mouse cursor to the given texture.
    public void setDefaultTexture()
    {
        this.GetComponent<SpriteRenderer>().sprite = defaultTexture;
        //Cursor.SetCursor(defaultTexture, hotSpot, cursorMode);
    }

    public void setMouse()
    {
        Cursor.SetCursor(mouse, hotSpot, cursorMode);
    }

    public void setHand()
    {
        Cursor.SetCursor(hand, hotSpot, cursorMode);
    }

    public void setGrab()
    {
        Cursor.SetCursor(grab, hotSpot, cursorMode);
    }
}
