using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointAudioScript : MonoBehaviour {

    //public
    public AudioClip checkpointClip;
    public static CheckpointAudioScript instance;

    //private
    AudioSource audioSource;

    private void Awake()
    {
        instance = this;
    }

    // Use this for initialization
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = checkpointClip;
    }

    // Update is called once per frame
    void Update () {
            
    }

    private void OnTriggerEnter(Collider collision)
    {
        audioSource.Play();
        Destroy(gameObject, audioSource.clip.length);
    }
}
