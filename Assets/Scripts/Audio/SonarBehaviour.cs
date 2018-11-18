using System.Collections;
using UnityEngine;

public class SonarBehaviour : MonoBehaviour {

    #region Properties and variables
    // public vars
    public AudioClip instrumentRadarSound;
    public AudioClip randomRadarSound;
    public AudioClip MusicClip;
    public GameObject target;
    public GameObject testObject;

    public static SonarBehaviour instance;
    public bool enableSonar;
    public bool enableInstrument;
    public bool findingTargetXZ;
    public bool objectFound;
    public bool isSphereActive;
    public bool isCubeActive;
    public bool isCylinderActive;




    // private vars
    AudioClip radarSound;
    AudioSource audioSource;
    bool isRadar;
   bool targetYDone;
    bool targetXZDone;
    float leftMotor;
    float rightMotor;
    float previousLeftMotor;
    float previousRightMotor;
    float previousDistance;
    float previousDistanceVib;
    float previousDistanceHeight;
    float previousDistanceXZ;
    float previousPitch;
    int tadaCounter;
    bool findingTargetYCube;
    bool findingTargetYSphere;

    bool isCube;
    bool isCylinder;
    bool isSphere;

    #endregion

    #region Unity Functions
    private void Awake()
    {
        instance = this;
    }
   
    private void Start()
    {
        isCube = false;
        isCylinder = false;
        isSphere = false;



        // private booleans
        isRadar = true;
        findingTargetYCube = true;
        findingTargetYSphere = true;
        findingTargetXZ = false;
        targetYDone = false;
        targetXZDone = false;
        


        objectFound = false;
        leftMotor = 0f;
        rightMotor = 0f;
        previousLeftMotor = 0f;
        previousRightMotor = 3.0f; // TODO change to CrateHeight
        previousDistance = float.MaxValue;
        previousDistanceVib = float.MaxValue;
        previousDistanceHeight = float.MaxValue;
        previousDistanceXZ = float.MaxValue;
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
        else
        {
            radarSound = randomRadarSound;
        }
        PlayAudio();
        if (enableSonar)
        {
            UpdateAudioSourcePitch();
        }
        else
        {
            audioSource.pitch = 1.0f;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Equals("Cursor"))
            isRadar = false;
        else
            isRadar = true;
    }

    /// <summary>
    /// isRadar - Turns radar sound off
    /// objectFound - Object was found
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
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

        //if (other.gameObject.name.Equals("Cursor"))
        //{
        //    enableVibration = true;
        //}
    }

    private void OnTriggerStay(Collider other)
    {
        //if (enableVibration)
        //{
        //    var distanceToTarget = Vector3.Distance(GameObject.Find("Cursor").transform.position, GameObject.Find("Crate").transform.position);
        //    if (distanceToTarget < previousDistanceVib)
        //    {
        //        previousDistanceVib = distanceToTarget;
        //        leftMotor = previousLeftMotor + 0.35f;
        //        previousLeftMotor = leftMotor;
        //    }
        //    else if (distanceToTarget > previousDistanceVib)
        //    {
        //        previousDistanceVib = distanceToTarget;
        //        leftMotor = previousLeftMotor - 0.35f;
        //        previousLeftMotor = leftMotor;
        //    }
        //    if(leftMotor <= 0f) //verifies if value is lower than 0
        //    {
        //        leftMotor = 0.1f; //give small value to keep motor working
        //    }
        //    GamePad.SetVibration(PlayerIndex.One, leftMotor, 0f);
        //}
        //else
        //    GamePad.SetVibration(PlayerIndex.One, 0f, 0f); //stops vibration
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
        //enableVibration = false;
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
        //var dist = Mathf.Abs(GameObject.Find("Sphere").transform.position.z - transform.position.z);
        //var targetV3Position = new Vector3(transform.position.x, transform.position.y, dist);
        //targetV3Position = Camera.main.ScreenToWorldPoint(targetV3Position);

        //var distanceToTarget = targetV3Position.magnitude;
        if (isRadar && audioSource.clip == radarSound)
        {
            var distanceToTarget = Vector3.Distance(GameObject.Find("Cursor").transform.position, transform.position);
            //var distanceToTarget = Vector3.Distance(targetV3Position, transform.position);
            //var distanceToTarget = Vector3.Distance(transform.position.z, GameObject.Find("Sphere").transform.position.z);

            //Debug.Log(distanceToTarget);
            if (distanceToTarget < previousDistance)
            {
                previousDistance = distanceToTarget;
                if (audioSource.pitch < 3.25f)
                    audioSource.pitch += 0.2f * Time.deltaTime;
            }
            else if (distanceToTarget > previousDistance)
            {
                if (previousPitch != 0) { 
                    audioSource.pitch = previousPitch;
                    previousPitch = 0f;
                }
                previousDistance = distanceToTarget;
                if (audioSource.pitch > 1.0f)
                    this.audioSource.pitch -= 0.2f * Time.deltaTime;
            }
        }
    }

    public static void FadeOutTestCaller(AudioSource audioSource, float FadeTime)
    {
        instance.StartCoroutine(FadeOutTest(audioSource, FadeTime));
    }

        public static IEnumerator FadeOutTest(AudioSource audioSource, float FadeTime)
    {
        float startVolume = audioSource.volume;

        while (audioSource.volume > 0)
        {
            audioSource.volume -= startVolume * Time.deltaTime / FadeTime;

            yield return null;
        }

        audioSource.Stop();
        audioSource.volume = startVolume;
    }

    private void OnMouseDrag()
    {
        audioSource.Stop();
    }
    #endregion
}