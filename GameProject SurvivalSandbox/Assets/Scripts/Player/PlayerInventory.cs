using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour {

    public GameObject slot_model;

    public GameObject backpack;

    private GameObject backpack_grid;
    private GameObject[] slots;

    private int backpack_max_size;

    private GameObject cap_max;
    private GameObject cap_act;
    private GameObject slot_max;
    private GameObject slot_act;

    private bool init;


    // Use this for initialization
    void Start () {

        this.backpack_max_size = PlayerConfig.max_inventory_slots;
        init = false;
    }
	
	// Update is called once per frame
	void Update () {

        if (!init && GameObject.FindGameObjectWithTag("Backpack")) {

            cap_max = GameObject.FindGameObjectWithTag("CapMax");
            cap_act = GameObject.FindGameObjectWithTag("CapAct");
            slot_max = GameObject.FindGameObjectWithTag("SlotsMax");
            slot_act = GameObject.FindGameObjectWithTag("SlotsFree");

            this.backpack_grid = GameObject.FindGameObjectWithTag("BackpackGrid");

            this.PrepareBackpack();

            init = true;

        }

        if(init) {

            if (PlayerGuiController.show_backpack) {

                RedrawBackpack();

                // Redraw count and capacity
                cap_max.GetComponent<Text>().text = "" + Inventory.capacity_max;
                cap_act.GetComponent<Text>().text = "" + (Inventory.capacity_max - Inventory.current_capacity);
                slot_max.GetComponent<Text>().text = "" + Inventory.maximum_backpack_items;
                slot_act.GetComponent<Text>().text = "" + Inventory.free_backpack_slots;
            }
        }


    }


    // Prepares backpack slot rendering
    void PrepareBackpack() {

        slots = new GameObject[backpack_max_size];

        for (int i = 0; i < backpack_max_size; i++) {

            // draw slots in grid
            slots[i] = Instantiate(slot_model);
            slots[i].transform.SetParent(backpack_grid.transform);

            slots[i].name = TextUtilities.TrimClone(slots[i].name);
        }

    }


    // Redraw backpack and its contents
    void RedrawBackpack() {

        // foreach item slot
        for (int i = 0; i < backpack_max_size; i++) {

            //Transform slot = Utilities.GetChildrenByName(slots[i], "BackpackSlotItem");
            Transform slot_item = Utilities.GetChildrenByName(slots[i], "SlotItem");
            Transform count = Utilities.GetChildrenByName(slots[i], "Count");

            slot_item.GetComponent<Image>().enabled = true;
            //count.gameObject.SetActive(true);

            if (i >= Inventory.maximum_backpack_items) { // slot is out limit

                //slots[i].GetComponent<Image>().color = Colors.backpack_limited;
                slot_item.GetComponent<Image>().color = Colors.backpack_limited;
                //slot_item.GetComponent<Image>().enabled = false;

                count.gameObject.SetActive(false);

                continue;
            }

            if (!Inventory.items[i].free) { // slot is occupied

                //slot_item.GetComponent<Image>().sprite = ItemDatabase.GetSprite(Inventory.items[i].item.name);
                count.GetComponent<Text>().text = "" + Inventory.items[i].item.count;
                count.gameObject.SetActive(true);

            } else {

                count.gameObject.SetActive(false);
                //slot_item.GetComponent<Image>().enabled = false;
            }

        }
    }
}
