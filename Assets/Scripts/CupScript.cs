using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupScript : MonoBehaviour {

    private void OnTriggerEnter(Collider collision)
    {
        LevelControlScript.instance.youWin();
    }
}
