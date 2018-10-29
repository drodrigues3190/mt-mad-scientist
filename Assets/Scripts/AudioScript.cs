using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScript : MonoBehaviour {

    public AudioClip MusicClip;
    RaycastHit hit;
    int count = 0;
    Ray ray;

    AudioSource MusicSource;

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
                
                if (MusicSource.clip != MusicClip)
                {
                    MusicSource.Stop();
                    MusicSource.clip = MusicClip;
                }

                if (!MusicSource.isPlaying)
                {
                    if(count == 0) { 
                        MusicSource.Play();
                         count = 1;
                    }
                }
            }
        }
        else count = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("wentrei");
        MusicSource = GetComponent<AudioSource>();
        this.MusicSource.Stop();
        this.MusicSource.clip = MusicClip;
        this.MusicSource.Play();
        //if (this.MusicSource.clip != MusicClip)
        //{
        //    this.MusicSource.Stop();
        //    this.MusicSource.clip = MusicClip;
        //}

        //if (!this.MusicSource.isPlaying)
        //        this.MusicSource.Play();
    }
}   
