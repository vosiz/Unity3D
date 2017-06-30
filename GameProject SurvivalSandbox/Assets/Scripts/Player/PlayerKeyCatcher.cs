using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKeyCatcher : MonoBehaviour {


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        /********************
            PRESSED
         *******************/
        // Interaction button
        if (this.KeyPressed("Interact")) {

            //Debug.Log("Interact pressed");
            PlayerStatus.interaction = true;
        } else {

            PlayerStatus.interaction = false;
        }

        // Open Backpack
        if (this.KeyPressed("Backpack")) {

            PlayerGuiController.ToggleShowBackpack();
        }


        /********************
            HELD
         *******************/
        if (this.KeyHold("ShowTooltip")) {

            PlayerGuiController.show_tooltip_btn = true;
        }else {
            PlayerGuiController.show_tooltip_btn = false;
        }


    }



    // Wrapper for key pressing
    bool KeyPressed(string key) { return Input.GetButtonDown(key); }
    bool KeyReleased(string key) { return Input.GetButtonUp(key); }
    bool KeyHold(string key) { return Input.GetButton(key); }
}
