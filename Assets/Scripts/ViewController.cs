using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ViewController : MonoBehaviour {

    public GameObject Cube;
    public GameObject Cylinder;
    public GameObject Sphere;

    public Text sonarBehaviourButtonText;
    public Text musicButtonText;

    private SonarBehaviour cubeSonarScript;
    private SonarBehaviour cylinderSonarScript;
    private SonarBehaviour sphereSonarScript;

    private void Start()
    {
        cubeSonarScript = Cube.GetComponent<SonarBehaviour>();
        cylinderSonarScript = Cylinder.GetComponent<SonarBehaviour>();
        sphereSonarScript = Sphere.GetComponent<SonarBehaviour>();
    }

    public void ChangeSonarBehaviourButtonText()
    {
        if (sonarBehaviourButtonText.text == "Enable")
            sonarBehaviourButtonText.text = "Disable";
        else
            sonarBehaviourButtonText.text = "Enable";
    }

    public void ManageSonarBehaviour()
    {
        if (sonarBehaviourButtonText.text == "Enable")
        {
            cubeSonarScript.enableSonar = false;
            cylinderSonarScript.enableSonar = false;
            sphereSonarScript.enableSonar = false;
        }
        else
        {
            cubeSonarScript.enableSonar = true;
            cylinderSonarScript.enableSonar = true;
            sphereSonarScript.enableSonar = true;
        }
    }

    public void ChangeMusicButtonText()
    {
        if (musicButtonText.text == "Random")
            musicButtonText.text = "Instruments";
        else
            musicButtonText.text = "Random";
    }

    public void ManageMusic()
    {
        if (musicButtonText.text == "Random")
        {
            cubeSonarScript.enableInstrument = true;
            cylinderSonarScript.enableInstrument = true;
            sphereSonarScript.enableInstrument = true;
        }
        else
        {
            cubeSonarScript.enableInstrument = false;
            cylinderSonarScript.enableInstrument = false;
            sphereSonarScript.enableInstrument = false;
        }
    }
}
