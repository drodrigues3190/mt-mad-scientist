using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCollision : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Object Entered the trigger");
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("Object is wihtin the trigger");
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Object exited the trigger");
    }

}
