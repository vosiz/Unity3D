using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectTooltip : MonoBehaviour {


    // Use this for initialization
    void Start () {

	}
	
	// Update
	void FixedUpdate () {

        if(PlayerCasting.distance < PlayerConfig.tooltip_display_distance) {

            if(PlayerConfig.tooltip_show_always) {



            }else {

                // TODO: On button press
            }
        }

	}
}
