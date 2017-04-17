using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour {

    static protected PlayerCasting pc = new PlayerCasting();

    protected string object_name;
    protected string primary_user_action;

    protected float distance;
    protected GameObject text_displayer;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    protected void OnMouseOver() {

        distance = pc.GetDistance();

        if (distance <= 4) {
            text_displayer.GetComponent<Text>().text = primary_user_action + " " + name;

            if (Input.GetButtonDown("Action")) {

                this.gameObject.SetActive(false);
                text_displayer.GetComponent<Text>().text = "";
            }
        }
    }

    void OnMouseExit() {

        text_displayer.GetComponent<Text>().text = "";
    }
}
