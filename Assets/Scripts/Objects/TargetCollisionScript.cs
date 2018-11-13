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
        var sonarBehaviour = other.GetComponent<SonarBehaviour>();
        sonarBehaviour.targetFound = true;
    }
}
