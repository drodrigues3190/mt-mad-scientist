using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XInputDotNetPure;

public class VibrationControllerScript : MonoBehaviour {

    public CheckpointAudioScript cpScript;
    float start = 1.0f;
    float end = 1.0f;
    bool canVibrate;

    private void Start()
    {
        canVibrate = false;
    }

    private void Update()
    {
    }

    void FixedUpdate()
    {
        //if (canVibrate)
        //{
        //    GamePad.SetVibration(PlayerIndex.One, start, end);
        //    start -= 0.01f;
        //    end -= 0.01f;
        //}
    }

    private void OnTriggerEnter(Collider other)
    {

        Vibrate();
        return;
    }

    public void Vibrate()
    {
        while(start>0.0f && end > 0.0f)
        {
            GamePad.SetVibration(PlayerIndex.One, start, end);
            start = start - 0.1f;
            end = end - 0.1f;
        }
    }

}
