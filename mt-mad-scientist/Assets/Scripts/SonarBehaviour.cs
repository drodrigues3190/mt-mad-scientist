using System.Collections;
using UnityEngine;

public class SonarBehaviour : MonoBehaviour {

    #region Properties
    AudioSource audioSource;

    private float previousDistance;

    private RaycastHit hit;
    private Ray ray;

    public static SonarBehaviour instance;

    #endregion

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        this.previousDistance = float.MaxValue;
        this.audioSource = GetComponent<AudioSource>();
        this.audioSource.Play();
    }


    private void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        var dist = Mathf.Abs(transform.position.z - Camera.main.transform.position.z);
        var targetV3Position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, dist);
        targetV3Position = Camera.main.ScreenToWorldPoint(targetV3Position);

        var distanceToTarget = Vector3.Distance(targetV3Position, transform.position);
        Debug.Log("Mouse position: " + distanceToTarget + "   Char position: " + previousDistance);

        
        if (distanceToTarget < previousDistance)
        {
            previousDistance = distanceToTarget;
            if(audioSource.pitch < 3.25f)
                this.audioSource.pitch += 0.25f * Time.deltaTime;
            Debug.Log("pitch"+ this.audioSource.pitch);

            if (Physics.Raycast(ray, out hit))
            {
                this.audioSource.pitch = 3.25f;
                //print(hit.collider.name);
            }
        }
        else if (distanceToTarget > previousDistance)
        {
            previousDistance = distanceToTarget;
            if (audioSource.pitch > 1.0f)
                this.audioSource.pitch -= 0.25f * Time.deltaTime;
        }
    }

    /// <summary>
    /// Function to fade out the audioSource
    /// </summary>
    /// <param name="audioSource"></param>
    /// <param name="FadeTime"></param>
    public void FadeOut(AudioSource audioSource, float FadeTime)
    {
        float startVolume = audioSource.volume;

        while (audioSource.volume > 0)
        {
            print("ola");
            audioSource.volume -= startVolume * Time.deltaTime / FadeTime;
        }

        audioSource.Stop();
        audioSource.volume = startVolume;
    }

    /// <summary>
    /// Function to fade in the audioSource
    /// </summary>
    /// <param name="audioSource"></param>
    /// <param name="FadeTime"></param>
    public void FadeIn(AudioSource audioSource, float FadeTime)
    {
        float startVolume = audioSource.volume;

        while (audioSource.volume > 0)
        {
            audioSource.volume += startVolume * Time.deltaTime / FadeTime;
        }

        audioSource.Stop();
        audioSource.volume = startVolume;
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
}
