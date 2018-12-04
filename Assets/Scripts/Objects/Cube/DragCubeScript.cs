using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XInputDotNetPure;

public class DragCubeScript : MonoBehaviour {

    #region properties
    // public
    public GameObject sphere;
    public GameObject cylinder;
    public GameObject cursor3D;
    public float movSpeed;
    public Rigidbody rigidBody;

    // private
    SonarBehaviour sonarBehaviourScript;
    CubeVibrationScript cubeVibrationScript;
    #endregion

    #region unity functions
    // Use this for initialization
    void Start()
    {
        sonarBehaviourScript = gameObject.GetComponent<SonarBehaviour>();
        cubeVibrationScript = gameObject.GetComponent<CubeVibrationScript>();
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
            GamePad.SetVibration(PlayerIndex.One, 0f, 1f);
        }
        if (Input.GetButtonUp("AButton"))
        {
            GamePad.SetVibration(PlayerIndex.One, 0f, 0f);
        }
    }

    // Triggers
    private void OnRBTriggerDown()
    {
        if (Input.GetButtonDown("RBTrigger") && sonarBehaviourScript.isCubeActive)
        {
            
            cubeVibrationScript.enableVibration = true;
            if(null != sphere)
                sphere.GetComponent<SphereVibrationScript>().enabled = false;
            if(null != cylinder)
                cylinder.GetComponent<CylinderVibrationScript>().enabled = false;

        }
    }

    // Triggers
    private void OnRBTriggerUp()
    {
        if (Input.GetButtonUp("RBTrigger"))
        {
            if (!cubeVibrationScript.targetFound)
            {
                cubeVibrationScript.enableVibration = false;
                cubeVibrationScript.findingTargetY = true;
                sonarBehaviourScript.isCubeActive = false;
                if (null != sphere)
                    sphere.GetComponent<SphereVibrationScript>().enabled = true;
                if (null != cylinder)
                    cylinder.GetComponent<CylinderVibrationScript>().enabled = true;
            }
        }
    }

    /// <summary>
    /// Function that allows to drag an object with right analog stick
    /// </summary>
    private void OnRightStickDrag()
    {
        if (sonarBehaviourScript.objectFound)
        {
            if (Input.GetButton("RBTrigger") && sonarBehaviourScript.isCubeActive)
            {
                rigidBody.useGravity = false;
                cursor3D.transform.position = transform.position;
                if (cubeVibrationScript.findingTargetY)
                    transform.Translate(0, movSpeed * Input.GetAxisRaw("Right Stick Y Axis") * Time.deltaTime, 0);
                else
                    transform.Translate(movSpeed * Input.GetAxisRaw("Left Stick X Axis") * Time.deltaTime, 0, movSpeed * Input.GetAxisRaw("Left Stick Y Axis") * Time.deltaTime);
            }
            else
                rigidBody.useGravity = true;
        }
    }
    #endregion
}
