using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour {

    #region Properties and variables
    // public vars
    public GameObject Cube;
    public GameObject Cylinder;
    public GameObject Sphere;

    public AudioSource cubeAudioSource;
    public AudioSource cylinderAudioSource;
    public AudioSource sphereAudioSource;

    // private vars
    private SonarBehaviour cubeSonarScript;
    private SonarBehaviour cylinderSonarScript;
    private SonarBehaviour sphereSonarScript;
    #endregion

    // Use this for initialization
    void Start () {
        cubeSonarScript = Cube.GetComponent<SonarBehaviour>();
        cylinderSonarScript = Cylinder.GetComponent<SonarBehaviour>();
        sphereSonarScript = Sphere.GetComponent<SonarBehaviour>();
    }
	
	// Update is called once per frame
	void Update () {
        if (sphereSonarScript.objectFound)
        {
            cubeAudioSource.mute = true;
            cylinderAudioSource.mute = true;
        }
        else
        {
            cubeAudioSource.mute = false;
            cylinderAudioSource.mute = false;
        }
	}
}
