using System.Collections;
using UnityEngine;

public class SonarBehaviour : MonoBehaviour {

    #region Properties and variables
    // public vars
    public AudioClip instrumentRadarSound;
    public AudioClip randomRadarSound;
    public AudioClip MusicClip;
    public AudioClip wordSound;

    public GameObject target;
    public GameObject testObject;

    public static SonarBehaviour instance;

    public bool enableMixedSonar;
    public bool enableSonar;
    public bool enableInstrument;
    public bool enableWords;
    public bool findingTargetXZ;
    public bool objectFound;
    public bool isSphereActive;
    public bool isCubeActive;
    public bool isCylinderActive;

    // private vars
    AudioClip radarSound;
    AudioSource audioSource;

    bool isRadar;
    bool updateOnce = true;

    float previousDistance;
    float previousPitch;
    int tadaCounter;
    #endregion

    #region Unity Functions
    private void Awake()
    {
        instance = this;
    }
   
    private void Start()
    {
        enableMixedSonar = false;
        enableSonar = false;

        // private booleans
        isRadar = true;
        findingTargetXZ = false;
        objectFound = false;
        previousDistance = float.MaxValue;
        previousPitch = 0f;
        tadaCounter = 0;
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (enableInstrument)
        {
            radarSound = instrumentRadarSound;
        }
        else if (enableWords)
        {
            radarSound = wordSound;
        }
        else
        {
            radarSound = randomRadarSound;
        }
        PlayAudio();
        if (enableSonar)
        {
            if (enableMixedSonar)
            {
                if (updateOnce)
                {
                    audioSource.pitch = 1.0f;
                    updateOnce = false;
                }
                UpdateAudioSourcePitchMixed();
            }
            else
                UpdateAudioSourcePitch();
        }
        else
        {
            audioSource.pitch = 1.0f;
        }
    }

    /// <summary>
    /// isRadar - Turns radar sound off
    /// objectFound - Object was found
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "crates_Smallfullopen_LOD0")
        {
        }
        else { 
            isRadar = false;
            objectFound = true;
            switch (testObject.name)
            {
                case "Sphere":
                    isSphereActive = true;
                    break;
                case "Cube":
                    isCubeActive = true;
                    break;
                case "Cylinder":
                    isCylinderActive = true;
                    break;
            }
        }
    }

    /// <summary>
    /// isRadar - Turns radar sound on
    /// enableVibration - Disable gamepad vibration
    /// objectFound - Object is lost again
    /// tadaCounter - Reset tada counter
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerExit(Collider other)
    {
        isRadar = true;
        objectFound = false;
        switch (testObject.name)
        {
            case "Sphere":
                isSphereActive = false;
                break;
            case "Cube":
                isCubeActive = false;
                break;
            case "Cylinder":
                isCylinderActive = false;
                break;
        }
        tadaCounter = 0;
    }
    #endregion

    #region Custom Functions
    /// <summary>
    /// Plays audio file.
    /// </summary>
    private void PlayAudio()
    {
        if (isRadar)
        {
            if (audioSource.clip != radarSound)
            {
                audioSource.Stop();
                audioSource.clip = radarSound;
            }

            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
        else
        {
            if (audioSource.clip != MusicClip)
            {
                audioSource.Stop();
                audioSource.clip = MusicClip;
            }

            if (!audioSource.isPlaying)
            {
                if (tadaCounter == 0)
                {
                    previousPitch = audioSource.pitch;
                    audioSource.pitch = 1.0f;
                    audioSource.PlayOneShot(MusicClip);
                    tadaCounter = 1;
                }
            }
        }
    }

    /// <summary>
    /// Sonar behaviour by changing the pitch value
    /// </summary>
    private void UpdateAudioSourcePitch()
    {
        if (isRadar && audioSource.clip == radarSound)
        {
            var distanceToTarget = Vector3.Distance(GameObject.Find("Cursor").transform.position, transform.position);
            Debug.Log(distanceToTarget);
            if (distanceToTarget < previousDistance)
            {
                previousDistance = distanceToTarget;
                if (audioSource.pitch < 3.25f)
                    audioSource.pitch += 0.2f * Time.deltaTime;
            }
            else if (distanceToTarget > previousDistance)
            {
                if (previousPitch != 0)
                {
                    audioSource.pitch = previousPitch;
                    previousPitch = 0f;
                }
                previousDistance = distanceToTarget;
                if (audioSource.pitch > 1.0f)
                    this.audioSource.pitch -= 0.2f * Time.deltaTime;
            }
        }
    }

    /// <summary>
    /// Mixed sonar behaviour by changing the pitch value
    /// </summary>
    private void UpdateAudioSourcePitchMixed()
    {
        if (isRadar && audioSource.clip == radarSound)
        {
            var distanceToTarget = Vector3.Distance(GameObject.Find("Cursor").transform.position, transform.position);
            Debug.Log(distanceToTarget);
            if (distanceToTarget < previousDistance && distanceToTarget <= 3.0f)
            {
                previousDistance = distanceToTarget;
                if (audioSource.pitch < 3.25f)
                    audioSource.pitch += 0.2f * Time.deltaTime;
            }
            else if (distanceToTarget > previousDistance)
            {
                if (previousPitch != 0)
                {
                    audioSource.pitch = previousPitch;
                    previousPitch = 0f;
                }
                previousDistance = distanceToTarget;
                if (audioSource.pitch > 1.0f)
                    this.audioSource.pitch -= 0.2f * Time.deltaTime;
            }
        }
    }
    #endregion
}