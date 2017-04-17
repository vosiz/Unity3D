using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoneObject : MonoBehaviour {

    private string name = "Stone";
    private string primary_action_text = "Collect ";

    static PlayerCasting pc = new PlayerCasting();

    public float distance;
    public GameObject text_displayer;

	// Update is called once per frame
	void OnMouseOver () {
        distance = pc.GetDistance();

        if (distance <= 4)
        {
            text_displayer.GetComponent<Text>().text = primary_action_text + name;

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
