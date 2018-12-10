using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkullScript : MonoBehaviour {

    private void OnTriggerEnter(Collider collision)
    {
        LevelControlScript.instance.youLose();
    }
}
