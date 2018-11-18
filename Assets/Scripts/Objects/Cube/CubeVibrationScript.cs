using System.Collections;
using System.Collections.Generic;
using XInputDotNetPure;
using UnityEngine;

public class CubeVibrationScript : MonoBehaviour {

    #region Properties
    // Public Vars
    public static CubeVibrationScript instance;
    public bool enableVibration;
    public bool findingTargetY;
    public bool targetFound;
    #endregion

    #region Unity Functions
    private void Awake()
    {
        instance = this;
    }

    // Use this for initialization
    void Start()
    {
        enableVibration = false;
        findingTargetY = true;
        targetFound = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!targetFound)
            FindCubeTarget();
    }
    #endregion

    #region Custom Functions
    private void FindTargetAxisY()
    {
        if (transform.position.y > 5.0f)
        {
            findingTargetY = false;
        }
        else if (transform.position.y >= 3.5f && transform.position.y <= 5.0f)
        {
            GamePad.SetVibration(PlayerIndex.One, 0, 0.25f);
        }
        else if (transform.position.y < 3.5f)
        {
            GamePad.SetVibration(PlayerIndex.One, 0, 1f);
        }
    }

    private void FindTargetAxisXZ() // TODO update this function
    {
        Vector2 targetPosition = new Vector2(-1.25f, 0.8f); // TODO Change this later to a generic position
        Vector2 currentPosition = new Vector2(transform.position.x, transform.position.z);
        var distanceToTarget = Vector2.Distance(currentPosition, targetPosition);

        if (distanceToTarget < 0.3f) // TODO remove fixed values
        {
            GamePad.SetVibration(PlayerIndex.One, 0.0f, 0.0f);
        }
        else if (distanceToTarget >= 0.3f && distanceToTarget <= 2.0f)
        {
            GamePad.SetVibration(PlayerIndex.One, 0.25f, 0.0f);
        }
        else if (distanceToTarget > 2.0f)
        {
            GamePad.SetVibration(PlayerIndex.One, 1.0f, 0.0f);
        }
    }

    private void FindCubeTarget()
    {
        if (enableVibration)
        {
            if (findingTargetY)
                FindTargetAxisY();
            else
                FindTargetAxisXZ();
        }
        else
            GamePad.SetVibration(PlayerIndex.One, 0.0f, 0.0f);
    }
    #endregion
}
