using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryPanel : MonoBehaviour {

    int backpack_max_size = 40;
    int backpack_init_size = 4;
    float backpack_capacity_init_size = 1.0f;

    public GameObject backpack_panel;

    public GameObject max_slots_panel;
    public GameObject occ_slots_panel;
    public GameObject max_capacity_panel;
    public GameObject capacity_panel;
    public GameObject backpack_grid;

    public GameObject slot_model;
    public GameObject[] slots;

    public GameObject crafting_panel;



	// Use this for initialization
	void Start () {

        backpack_max_size = GameScenario.backpack_max_size;
        backpack_init_size = GameScenario.backpack_init_size;
        backpack_capacity_init_size = GameScenario.backpack_capacity_init_size;

        GameManager.backpack_open_state = false;
        GameManager.crafting_open_state = false;

        Inventory.initInventory(backpack_init_size, backpack_max_size, backpack_capacity_init_size);

        this.slots = new GameObject[backpack_max_size];
        this.PrepareBackpack();
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetButtonDown("Inventory")) { // open or closes backpack

            GameManager.backpack_open_state = !GameManager.backpack_open_state;
        }


        if (Input.GetButtonDown("Crafting")) { // open or closes backpack

            GameManager.backpack_open_state = true;
            GameManager.crafting_open_state = !GameManager.crafting_open_state;
        }


        backpack_panel.gameObject.SetActive(GameManager.backpack_open_state);
        crafting_panel.gameObject.SetActive(GameManager.crafting_open_state);


        max_slots_panel.GetComponent<Text>().text = "" + Inventory.maximum_backpack_items;
        occ_slots_panel.GetComponent<Text>().text = "" + Inventory.current_items;

        max_capacity_panel.GetComponent<Text>().text = "" + Inventory.capacity_max;
        capacity_panel.GetComponent<Text>().text = "" + Inventory.current_capacity;

        RedrawBackpack();


        GameManager.fsp_controls_enabled = !GameManager.backpack_open_state;
    }

    /* Prepares backpack slot rendering*/
    void PrepareBackpack() {

        for (int i = 0; i < backpack_max_size; i++) {

            slots[i] = Instantiate(slot_model);
            slots[i].transform.SetParent(backpack_grid.transform);
        }

    }

    /* Redraws backapck content*/
    void RedrawBackpack() {

        for (int i = 0; i < backpack_max_size; i++) {

            Transform slot_item = Utilities.GetChildrenByName(slots[i], "SlotItem");
            Transform count = Utilities.GetChildrenByName(slots[i], "ItemCount");

            slot_item.GetComponent<Image>().enabled = true;

            if (i >= Inventory.maximum_backpack_items) { // slot is out limit

                slots[i].GetComponent<Image>().color = Colors.backpack_limited;
                slot_item.GetComponent<Image>().enabled = false;
                continue;
            }

            if (!Inventory.items[i].free) { // slot is occupied, draw with what

                slot_item.GetComponent<Image>().sprite = ItemDatabase.GetSprite(Inventory.items[i].item.name);
                count.GetComponent<Text>().text = "" + Inventory.items[i].item.count;

            } else {

                slot_item.GetComponent<Image>().enabled = false;
            }
            //Utilities.GetChildrenByName(slots[i], "SlotItem").GetComponent<Image>().color = Colors.backpack_limited;

        }
    }

}
