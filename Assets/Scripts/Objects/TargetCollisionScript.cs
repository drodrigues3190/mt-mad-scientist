using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetCollisionScript : MonoBehaviour {

    #region properties
    // public vars
    public List<GameObject> objects;
    #endregion

    #region unity default methods
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    #endregion

    private void OnTriggerEnter(Collider other)
    {
        var sonarScript = other.GetComponent<SonarBehaviour>();
        switch (other.name)
        {
            case "Sphere":
                var sphereVibration = other.GetComponent<SphereVibrationScript>();
                var dragSphere = other.GetComponent<DragSphereScript>();
                sonarScript.isSphereActive = false;
                sphereVibration.spheretargetFound = true;
                Destroy(sonarScript);
                Destroy(sphereVibration);
                Destroy(dragSphere);
                break;
            case "Cube":
                var cubeVibration = other.GetComponent<CubeVibrationScript>();
                var dragCube = other.GetComponent<DragCubeScript>();
                sonarScript.isSphereActive = false;
                cubeVibration.targetFound = true;
                Destroy(sonarScript);
                Destroy(cubeVibration);
                Destroy(dragCube);
                break;
            case "Cylinder":
                break;
        }

        // Destroy(other);
    }
}
