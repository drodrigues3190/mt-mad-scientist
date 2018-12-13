using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePadControllerScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update ()
    {
        OnButtonY();
    }

    void OnButtonY()
    {

            if (Input.GetButton("YButton"))
                Invoke("loadMainMenu", 0f);
    }

    void loadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
