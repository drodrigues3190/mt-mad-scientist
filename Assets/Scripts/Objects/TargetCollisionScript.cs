using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetCollisionScript : MonoBehaviour {

    #region properties
    // public vars
    public List<GameObject> objects;
    public AudioSource cubeAudioSource;
    public AudioSource cylinderAudioSource;
    public AudioSource sphereAudioSource;

    // private vars
    AudioSource targetAudioSource;
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
        var audioSource = this.gameObject.GetComponent<AudioSource>();
        audioSource.Play();
        switch (other.name)
        {
            case "Sphere":
                //var sphereVibration = other.GetComponent<SphereVibrationScript>();
                //var dragSphere = other.GetComponent<DragSphereScript>();
                //sonarScript.isSphereActive = false;
                //sphereVibration.spheretargetFound = true;
                //Destroy(sonarScript);
                //Destroy(sphereVibration);
                //Destroy(dragSphere);
               // Destroy(other.gameObject);
                other.GetComponent<SphereVibrationScript>().enabled = false;
                other.GetComponent<DragSphereScript>().enabled = false;
                other.GetComponent<AudioSource>().enabled = false;
                //other
                //var cube = GameObject.Find("Cube");
                //cube.GetComponent<SonarBehaviour>().enableSonar = true;
                break;
            case "Cube":
                other.GetComponent<CubeVibrationScript>().enabled = false;
                other.GetComponent<DragCubeScript>().enabled = false;
                other.GetComponent<AudioSource>().enabled = false;
                // var cubeVibration = other.GetComponent<CubeVibrationScript>();
                // var dragCube = other.GetComponent<DragCubeScript>();
                // sonarScript.isSphereActive = false;
                // cubeVibration.targetFound = true;
                //// Destroy(sonarScript);
                // Destroy(cubeVibration);
                // Destroy(dragCube);
                break;
            case "Cylinder":
                other.GetComponent<CylinderVibrationScript>().enabled = false;
                other.GetComponent<DragCylinderScript>().enabled = false;
                other.GetComponent<AudioSource>().enabled = false;
                break;
        }

        // Destroy(other);
    }
}
