using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XInputDotNetPure;

public class DragObjectScript : MonoBehaviour
{

    #region properties
    // public
    public GameObject cursor3D;
    public float movSpeed;
    public Rigidbody rigidBody;

    // private
    SonarBehaviour sonarBehaviourScript;
    #endregion

    #region unity functions
    // Use this for initialization
    void Start()
    {
        sonarBehaviourScript = gameObject.GetComponent<SonarBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        OnRBTriggerDown();
        OnRBTriggerUp();
        OnButtonADown();
        OnRightStickDrag();
    }
    #endregion

    #region custom functions
    // Buttons
    private void OnButtonADown()
    {
        if (Input.GetButton("AButton"))
        {
            GamePad.SetVibration(PlayerIndex.One, 0f, 0.175f);
        }
        if (Input.GetButtonUp("AButton"))
        {
            GamePad.SetVibration(PlayerIndex.One, 0f, 0f);
        }
        if (Input.GetButton("BButton"))
        {
            GamePad.SetVibration(PlayerIndex.One, 0f, 0f);
        }
        if (Input.GetButtonUp("BButton"))
        {
            GamePad.SetVibration(PlayerIndex.One, 0f, 0f);
        }
        if (Input.GetButton("YButton"))
        {
            GamePad.SetVibration(PlayerIndex.One, 0f, 0.35f);
        }
        if (Input.GetButtonUp("YButton"))
        {
            GamePad.SetVibration(PlayerIndex.One, 0f, 0f);
        }
        if (Input.GetButton("XButton"))
        {
            GamePad.SetVibration(PlayerIndex.One, 0f, 3.0f);
        }
        if (Input.GetButtonUp("XButton"))
        {
            GamePad.SetVibration(PlayerIndex.One, 0f, 0f);
        }
    }
    private void OnButtonBDown() { }
    private void OnButtonYDown() { }
    private void OnButtonXDown() { }

    // Triggers
    private void OnRBTriggerDown()
    {
        if (Input.GetButtonDown("RBTrigger"))
        {
        }
    }

    // Triggers
    private void OnRBTriggerUp()
    {
        if (Input.GetButtonUp("RBTrigger"))
        {

        }
    }

    /// <summary>
    /// Function that allows to drag an object with right analog stick
    /// </summary>
    private void OnRightStickDrag()
    {
        if (sonarBehaviourScript.objectFound)
        {
            if (Input.GetButton("RBTrigger"))
            {
                rigidBody.useGravity = false;
                cursor3D.transform.position = transform.position;
                transform.Translate(movSpeed * Input.GetAxisRaw("Left Stick X Axis") * Time.deltaTime, movSpeed * Input.GetAxisRaw("Right Stick Y Axis") * Time.deltaTime, movSpeed * Input.GetAxisRaw("Left Stick Y Axis") * Time.deltaTime);
            }
            else
                rigidBody.useGravity = true;
        }
    }
    #endregion
}

