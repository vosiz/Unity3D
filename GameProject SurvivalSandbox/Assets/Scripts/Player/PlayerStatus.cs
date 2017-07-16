using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static public class PlayerStatus {

    static public bool interaction = false;
    static public bool can_run = true;


    static public float GetFps() {

        return 1.0f / Time.deltaTime;
    }
}
