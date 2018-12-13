using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class CheckpointAudioScript : MonoBehaviour {

    //public
    public static CheckpointAudioScript instance;

    public AudioClip checkpointClip;

    public bool canDestroy;

    //private
    AudioSource audioSource;

    private void Awake()
    {
        instance = this;
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = checkpointClip;
    }

    // Use this for initialization
    void Start()
    {
        canDestroy = false;

        
    }

    // Update is called once per frame
    void Update () {
            
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (canDestroy)
        {
            this.audioSource.Play();
            Destroy(this.gameObject, audioSource.clip.length);
        }
    }

    /// <summary>
    /// Linear Rolloff settings
    /// </summary>
    public void LinearRolloff()
    {
        // General Settings
        audioSource.priority = 128; // TODO change to fixed value
        audioSource.volume = 1.0f; // TODO change to fixed value
        audioSource.pitch = 1.0f; // TODO change to fixed value
        audioSource.panStereo = 0.0f; // TODO change to fixed value
        audioSource.spatialBlend = 1.0f; // TODO change to fixed value
        audioSource.reverbZoneMix = 0.0f; // TODO change to fixed value

        // 3D Settings
        audioSource.rolloffMode = AudioRolloffMode.Linear;
        audioSource.dopplerLevel = 0.0f; // TODO change to fixed value
        audioSource.spread = 0.0f; // TODO change to fixed value
        audioSource.minDistance = 1.0f; // TODO change to fixed value
        audioSource.maxDistance = 4.25f;
    }

    /// <summary>
    /// Logarithmic Rolloff settings
    /// </summary>
    public void LogarithmicRolloff()
    {
        // General Settings
        audioSource.priority = 128; // TODO change to fixed value
        audioSource.volume = 1.0f; // TODO change to fixed value
        audioSource.pitch = 1.0f; // TODO change to fixed value
        audioSource.panStereo = 0.0f; // TODO change to fixed value
        audioSource.spatialBlend = 1.0f; // TODO change to fixed value
        audioSource.reverbZoneMix = 0.0f; // TODO change to fixed value

        // 3D Settings
        audioSource.rolloffMode = AudioRolloffMode.Logarithmic;
        audioSource.dopplerLevel = 0.0f; // TODO change to fixed value
        audioSource.spread = 0.0f; // TODO change to fixed value
        audioSource.minDistance = 1.0f; // TODO change to fixed value
        audioSource.maxDistance = 50.0f;
    }
}
