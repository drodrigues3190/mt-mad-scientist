using System.Collections;
using UnityEngine;

public class SonarBehaviour : MonoBehaviour {

    #region Properties
    // public vars
    public AudioClip radarSound;
    public AudioClip MusicClip;
    public static SonarBehaviour instance;

    // private vars
    AudioSource audioSource;

    bool isRadar = true;

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
        previousDistance = float.MaxValue;
        previousPitch = 0f;
        tadaCounter = 0;
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        //IsCollidingWithTarget();
        PlayAudio();
        UpdateAudioSourcePitch();
    }

    private void OnCollisionEnter(Collision collision)
    {
        /// Function that verifies if the cursor is colliding with target object.
        if (collision.gameObject.name.Equals("Sphere"))
            isRadar = false;
        else
            isRadar = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        isRadar = false;
    }


   /* private void OnTriggerStay(Collider other)
    {
        Debug.Log("ola");
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }*/

    private void OnTriggerExit(Collider other)
    {
        isRadar = true;
        tadaCounter = 0;
    }
    #endregion

    #region Custom Functions

    //private void IsCollidingWithTarget()
    //{
    //    ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    //    if (Physics.Raycast(ray, out hit))
    //    {
    //        if (hit.collider.name.Equals("Sphere"))
    //            isRadar = false;
    //    }
    //    else
    //        isRadar = true;
    //}

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
            //audioSource.Stop();
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
                    audioSource.Play();
                    tadaCounter += 1;
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
            var distanceToTarget = Vector3.Distance(GameObject.Find("Sphere").transform.position, transform.position);
            //var distanceToTarget = Vector3.Distance(targetV3Position, transform.position);
            //var distanceToTarget = Vector3.Distance(transform.position.z, GameObject.Find("Sphere").transform.position.z);

            //Debug.Log(distanceToTarget);
            if (distanceToTarget < previousDistance)
            {
                previousDistance = distanceToTarget;
                if (audioSource.pitch < 3.25f)
                    audioSource.pitch += 0.275f * Time.deltaTime;
            }
            else if (distanceToTarget > previousDistance)
            {
                if (previousPitch != 0) { 
                    audioSource.pitch = previousPitch;
                    previousPitch = 0f;
                }
                previousDistance = distanceToTarget;
                if (audioSource.pitch > 1.0f)
                    this.audioSource.pitch -= 0.275f * Time.deltaTime;
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