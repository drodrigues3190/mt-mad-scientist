using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControllerScript : MonoBehaviour {

    //public
    public GameObject checkpoint;
    public GameObject checkpoint1;
    public static GameControllerScript instance;

    //private

    private void Awake()
    {
        instance = this;
    }

    // Use this for initialization
    void Start ()
    {
        checkpoint.GetComponent<CheckpointAudioScript>().canDestroy = true;
        if(SceneManager.GetActiveScene().buildIndex < 4)
        {
            checkpoint1.GetComponent<SonarBehaviour>().enabled = false;
            checkpoint1.GetComponent<VibrationControllerScript>().enabled = false;
        }
        else
            checkpoint1.GetComponent<CheckpointAudioScript>().canDestroy = true;

    }
	
	// Update is called once per frame
	void Update () {
        if (SceneManager.GetActiveScene().buildIndex < 5)
        {
            if (null == checkpoint)
            {
                if (null != checkpoint1)
                {
                    checkpoint1.GetComponent<CheckpointAudioScript>().canDestroy = true;
                    checkpoint1.GetComponent<SonarBehaviour>().enabled = true;
                    checkpoint1.GetComponent<VibrationControllerScript>().enabled = true;
                }
                else
                    LevelControlScript.instance.youWin();
            }
        }
        else
        {
            if(null == checkpoint && null == checkpoint1)
            {
                LevelControlScript.instance.youWin();
            }
        }

	}
}
