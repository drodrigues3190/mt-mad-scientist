using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioInstructionsScript : MonoBehaviour {

    //public
    public AudioClip introductionClip;
    public AudioClip introductionStep2Clip;
    public AudioClip checkpointClip;
    public CheckpointAudioScript checkpoint;
    public GameControllerScript gameController;

    //private
    AudioSource audioSource;

    bool canPlayCheckpoint;
    bool playSoundOnce;

    // Use this for initialization
    void Start () {
        canPlayCheckpoint = true;
        playSoundOnce = false;
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(introductionClip);
    }

    // Update is called once per frame
    void Update () {
        if (!audioSource.isPlaying && audioSource.clip != checkpointClip && canPlayCheckpoint)
        {
            audioSource.PlayOneShot(checkpointClip);
            canPlayCheckpoint = false;
        }
        if(null==checkpoint && !playSoundOnce)
        {
            audioSource.PlayOneShot(introductionStep2Clip);
            playSoundOnce = true;
            gameController.canSpawn = true;
            return;
        }
    }
}
