using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScript : MonoBehaviour {

    public AudioClip MusicClip;
    RaycastHit hit;
    bool test = false;
    Ray ray;

    public AudioSource MusicSource;
    public AudioSource cameraAudioSouce;

	// Use this for initialization
	void Start () {
        MusicSource = GetComponent<AudioSource>();

    }
	
	// Update is called once per frame
	void Update () {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.name.Equals("Sphere"))
            {
                test = true;
                if (MusicSource.clip != MusicClip)
                {
                    MusicSource.Stop();
                    MusicSource.clip = MusicClip;
                }

                if (!MusicSource.isPlaying)
                {
                    MusicSource.Play();
                }
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        MusicSource.Play();
    }
}   
