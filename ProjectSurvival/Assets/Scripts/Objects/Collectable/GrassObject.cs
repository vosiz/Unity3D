using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GrassObject : MonoBehaviour {

    static PlayerCasting pc = new PlayerCasting();

    public float distance;
    public GameObject info_text_displayer;
    public GameObject action_text_displayer;
    public GameObject inventory;
    public int inv_space;

    public int debug;

    private InventoryItem item;

    void Start() {

        InventoryDatabase.InitItem("Grass", out this.item);
    }

    // Update is called once per frame
    void OnMouseOver() {

        distance = pc.GetDistance();
        inv_space = Inventory.free_backpack_slots;

        if (distance <= 4) { // is in distance

            if (inv_space == 0) {

                action_text_displayer.GetComponent<Text>().text = "Cannot " + item.action_text;
                action_text_displayer.GetComponent<Text>().color = new Color(1, 0, 0);
            } else {

                action_text_displayer.GetComponent<Text>().text = item.action_text;
            }

            
            info_text_displayer.GetComponent<Text>().text = item.name;

            if (Input.GetButtonDown("Action")) { //action button pressed

                if(Inventory.addItem(item)) {
                    this.gameObject.SetActive(false);
                    this.NoText();
                }

            }
        }
    }

    void OnMouseExit() {
        this.NoText();
    }

    // Set text to nothing
    void NoText() {
        info_text_displayer.GetComponent<Text>().text = "";
        action_text_displayer.GetComponent<Text>().text = "";
    }
}
