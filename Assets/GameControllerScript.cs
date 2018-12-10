using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerScript : MonoBehaviour {

    //public
    public Vector3 spawnLocation;
    public CheckpointAudioScript checkpointToEnable;
    public static GameControllerScript instance;
    public bool canSpawn;

    //private

    private void Awake()
    {
        instance = this;
    }

    // Use this for initialization
    void Start ()
    {
        canSpawn = false;
    }
	
	// Update is called once per frame
	void Update () {
        if(canSpawn)
        {
            checkpointToEnable.GetComponentInChildren<Renderer>().enabled = true;
            canSpawn = false;
        }
	}
}
