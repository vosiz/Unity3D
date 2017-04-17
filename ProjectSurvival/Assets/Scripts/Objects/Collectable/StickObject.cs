using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StickObject : MonoBehaviour {

    static PlayerCasting pc = new PlayerCasting();

    public float distance;
    public GameObject info_text_displayer;
    public GameObject action_text_displayer;
    public GameObject inventory;
    public int inv_space;

    public int debug;

    private InventoryItem item;

    void Start() {

        InventoryDatabase.InitItem("Wood stick", out this.item);
    }

    // Update is called once per frame
    void OnMouseOver() {

        distance = pc.GetDistance();
        inv_space = Inventory.free_backpack_slots;

        if (distance <= 4) { // is in distance

            if (!Inventory.canPickup(this.item)) {

                action_text_displayer.GetComponent<Text>().text = "Cannot " + item.action_text;
                action_text_displayer.GetComponent<Text>().color = Colors.info_text_neg;
            } else {

                action_text_displayer.GetComponent<Text>().color = Colors.info_text;
                action_text_displayer.GetComponent<Text>().text = item.action_text;
            }


            info_text_displayer.GetComponent<Text>().text = item.name + " (" + item.count + ")";

            if (Input.GetButtonDown("Action")) { //action button pressed

                int stored = Inventory.addItem(item);

                if (stored == item.count) { // all was taken, destroy item
                    this.gameObject.SetActive(false);
                    this.NoText();
                } else { // some or none has beeen stored

                    item.count -= stored;
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
