using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XInputDotNetPure;

public class DragCylinderScript : MonoBehaviour {

    #region properties
    // public
    public GameObject sphere;
    public GameObject cube;
    public GameObject cursor3D;
    public float movSpeed;
    public Rigidbody rigidBody;

    // private
    SonarBehaviour sonarBehaviourScript;
    CylinderVibrationScript cylinderVibrationScript;
    #endregion

    #region unity functions
    // Use this for initialization
    void Start()
    {
        sonarBehaviourScript = gameObject.GetComponent<SonarBehaviour>();
        cylinderVibrationScript = gameObject.GetComponent<CylinderVibrationScript>();
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
        if (Input.GetButtonDown("RBTrigger") && sonarBehaviourScript.isCylinderActive)
        {

            cylinderVibrationScript.enableCylinderVibration = true;
            if (null != sphere)
                sphere.GetComponent<SphereVibrationScript>().enabled = false;
            if (null != cube)
                cube.GetComponent<CubeVibrationScript>().enabled = false;
        }
    }

    // Triggers
    private void OnRBTriggerUp()
    {
        if (Input.GetButtonUp("RBTrigger"))
        {
            if (!cylinderVibrationScript.cylinderTargetFound)
            {
                cylinderVibrationScript.enableCylinderVibration = false;
                cylinderVibrationScript.cylinderFindingTargetY = true;
                sonarBehaviourScript.isCylinderActive = false;
                if (null != sphere)
                    sphere.GetComponent<SphereVibrationScript>().enabled = true;
                if (null != cube)
                    cube.GetComponent<CubeVibrationScript>().enabled = true;
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
            if (Input.GetButton("RBTrigger") && sonarBehaviourScript.isCylinderActive)
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
