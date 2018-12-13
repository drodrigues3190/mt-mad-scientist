using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour
{
    #region properties
    // public
    public Button linearRolloffButton;
    public Button logarithmicRolloffButton;
    public Button mixedSonarButton;
    public Button sonarButton;
    public Button instrumentsSoundsButton;
    public Button wordSoundsButton;

    public List<GameObject> gameObjects;

    public Text linearRolloffButtonText;
    public Text logarithmicRolloffButtonText;
    public Text mixedSonarButtonText;
    public Text musicButtonText;
    public Text sonarButtonText;
    public Text instrumentsSoundsButtonText;
    public Text wordSoundsButtonText;

    // private
    List<SonarBehaviour> sonarBehaviours;

    bool mixedSonarBehaviour;

    #endregion properties

    private void Start()
    {
        mixedSonarBehaviour = false;
        sonarBehaviours = new List<SonarBehaviour>();
        foreach (GameObject gameObject in gameObjects)
            sonarBehaviours.Add(gameObject.GetComponent<SonarBehaviour>());

        ActivateLogarithmicRolloff();
    }

    #region custom methods

    /// <summary>
    /// Enable/Disable Sonar Behaviour
    /// </summary>
    public void ManageSonarBehaviour()
    {
        if(sonarButton.image.color == Color.white)
        {
            sonarButton.image.color = Color.gray;
            sonarButtonText.color = Color.white;
            foreach (SonarBehaviour sonar in sonarBehaviours)
                sonar.enableSonar = true;
        }
        else
        {
            sonarButton.image.color = Color.white;
            sonarButtonText.color = new Color(0.196f, 0.196f, 0.196f);
            foreach (SonarBehaviour sonar in sonarBehaviours)
                sonar.enableSonar = false;
        }
    }

    /// <summary>
    /// Enable/Disable Instruments
    /// </summary>
    public void ManageInstrumentsSounds()
    {
        if (instrumentsSoundsButton.image.color == Color.white)
        {
            instrumentsSoundsButton.image.color = Color.gray;
            instrumentsSoundsButtonText.color = Color.white;
            foreach (SonarBehaviour sonar in sonarBehaviours)
                sonar.enableInstrument = true;
        }
        else
        {
            instrumentsSoundsButton.image.color = Color.white;
            instrumentsSoundsButtonText.color = new Color(0.196f, 0.196f, 0.196f);
            foreach (SonarBehaviour sonar in sonarBehaviours)
                sonar.enableInstrument = false;
        }
    }

    /// <summary>
    /// Active/Deactivate LinearRolloff
    /// </summary>
    public void ActivateLinearRolloff()
    {
        linearRolloffButton.image.color = Color.gray;
        linearRolloffButtonText.color = Color.white;

        //turn off logarithm button
        logarithmicRolloffButton.image.color = Color.white;
        logarithmicRolloffButtonText.color = new Color(0.196f, 0.196f, 0.196f);

        foreach (GameObject go in gameObjects)
        {
            var checkpointAudioScript = go.GetComponent<CheckpointAudioScript>();
            checkpointAudioScript.LinearRolloff();
        }
    }

    /// <summary>
    /// Active/Deactivate Logorithmic Rolloff
    /// </summary>
    public void ActivateLogarithmicRolloff()
    {
            logarithmicRolloffButton.image.color = Color.gray;
            logarithmicRolloffButtonText.color = Color.white;

            // turn off linear button
            linearRolloffButton.image.color = Color.white;
            linearRolloffButtonText.color = new Color(0.196f, 0.196f, 0.196f);

            foreach (GameObject go in gameObjects)
            {
                var checkpointAudioScript = go.GetComponent<CheckpointAudioScript>();
                checkpointAudioScript.LogarithmicRolloff();
            }
    }

    /// <summary>
    /// Enable/Disable Mixed Sonar Behaviour
    /// </summary>
    public void ManageMixedSonarBehaviour()
    {
        if (!mixedSonarBehaviour)
        {
            mixedSonarBehaviour = true;
            mixedSonarButton.image.color = Color.gray;
            mixedSonarButtonText.color = Color.white;
            foreach (SonarBehaviour sonar in sonarBehaviours)
                sonar.enableMixedSonar = true;
        }
        else
        {
            mixedSonarBehaviour = false;
            mixedSonarButton.image.color = Color.white;
            mixedSonarButtonText.color = new Color(0.196f, 0.196f, 0.196f);
            foreach (SonarBehaviour sonar in sonarBehaviours)
                sonar.enableMixedSonar = false;
        }
    }

    /// <summary>
    /// Enable/Disable Mixed Sonar Behaviour
    /// </summary>
    public void ManageWordSounds()
    {
        if (wordSoundsButton.image.color == Color.white)
        {
            wordSoundsButton.image.color = Color.gray;
            wordSoundsButtonText.color = Color.white;
            foreach (SonarBehaviour sonar in sonarBehaviours)
                sonar.enableWords = true;
        }
        else
        {
            wordSoundsButton.image.color = Color.white;
            wordSoundsButtonText.color = new Color(0.196f, 0.196f, 0.196f);
            foreach (SonarBehaviour sonar in sonarBehaviours)
                sonar.enableWords = false;
        }
    }
    #endregion
}