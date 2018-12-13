using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelControlScript : MonoBehaviour {

    public static LevelControlScript instance = null;
    GameObject levelSign;
    int sceneIndex, levelPassed;

	// Use this for initialization
	void Start () {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
        levelSign = GameObject.Find("LevelNumber");

        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        levelPassed = PlayerPrefs.GetInt("LevelPassed");
	}
	

    public void youWin()
    {
        if (sceneIndex == 5)
            Invoke("loadMainMenu", 1f);
        else
        {
            if (levelPassed < sceneIndex)
                PlayerPrefs.SetInt("LevelPassed", sceneIndex);
            levelSign.gameObject.SetActive(false);
            Invoke("loadNextLevel", 1f);
        }
    }

    public void youLose()
    {
        if (sceneIndex == 3)
            Invoke("loadMainMenu", 1f);
        else
        {
            if (levelPassed < sceneIndex)
                PlayerPrefs.SetInt("LevelPassed", sceneIndex);
            levelSign.gameObject.SetActive(false);
            Invoke("loadNextLevel", 1f);
        }
    }

    void loadNextLevel()
    {
        SceneManager.LoadScene(sceneIndex + 1);
    }

    void loadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
