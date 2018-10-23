using System.Collections;
using UnityEngine;

public class SonarBehaviour : MonoBehaviour {

    #region Properties
    // public vars
    public AudioClip radar;
    public static SonarBehaviour instance;


    // private vars
    AudioSource audioSource;
    RaycastHit hit;
    Ray ray;

    bool isRadar = false;

    float previousDistance;

    #endregion

    #region Unity Functions
    private void Awake()
    {
        instance = this;
    }
   
    private void Start()
    {
        previousDistance = float.MaxValue;
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        IsCollidingWithTarget();
        PlayAudio();
        UpdateAudioSourcePitch();        
    }
    #endregion

    #region Custom Functions
    /// <summary>
    /// Function that verifies if the cursor is colliding with target object.
    /// </summary>
    private void IsCollidingWithTarget()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
            isRadar = false;
        else
            isRadar = true;
    }

    /// <summary>
    /// Plays audio file.
    /// </summary>
    private void PlayAudio()
    {
        if (isRadar)
        {
            if (audioSource.clip != radar)
            {
                audioSource.Stop();
                audioSource.clip = radar;
            }

            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
        else
        {
            audioSource.Stop();
        }
    }

    /// <summary>
    /// Sonar behaviour by changing the pitch value
    /// </summary>
    private void UpdateAudioSourcePitch()
    {
        var dist = Mathf.Abs(GameObject.Find("14029_plastic_fruit_crate_SG").transform.position.z - transform.position.z);
        var targetV3Position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, dist);
        targetV3Position = Camera.main.ScreenToWorldPoint(targetV3Position);
        var distanceToTarget = Vector3.Distance(targetV3Position, transform.position);

        if (distanceToTarget < previousDistance)
        {
            previousDistance = distanceToTarget;
            if (audioSource.pitch < 3.25f)
                audioSource.pitch += 0.25f * Time.deltaTime;
        }
        else if (distanceToTarget > previousDistance)
        {
            previousDistance = distanceToTarget;
            if (audioSource.pitch > 1.0f)
                this.audioSource.pitch -= 0.25f * Time.deltaTime;
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
    #endregion
}