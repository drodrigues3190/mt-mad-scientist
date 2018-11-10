using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        OnRightStickDrag();
    }
    #endregion

    #region custom functions
    // Buttons
    private void OnButtonADown()
    {
        if (Input.GetButtonDown("AButton"))
        {
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
            sonarBehaviourScript.enableVibration = true;
        }
    }

    // Triggers
    private void OnRBTriggerUp()
    {
        if (Input.GetButtonUp("RBTrigger"))
        {
            sonarBehaviourScript.enableVibration = false;
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

