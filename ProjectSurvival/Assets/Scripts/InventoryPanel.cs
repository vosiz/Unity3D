﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryPanel : MonoBehaviour {

    static bool backpack_open_state;
    public GameObject backpack_panel;
    public GameObject max_slots_panel;
    public GameObject occ_slots_panel;
    public GameObject max_capacity_panel;
    public GameObject capacity_panel;

	// Use this for initialization
	void Start () {

        backpack_open_state = false;
        backpack_panel.gameObject.SetActive(backpack_open_state);

        Inventory.initInventory(4, 40, 1.0f);
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetButtonDown("Inventory")) { // open or closes inventory

            backpack_open_state = !backpack_open_state;
            backpack_panel.gameObject.SetActive(backpack_open_state);
        }

        max_slots_panel.GetComponent<Text>().text = "" + Inventory.maximum_backpack_items;
        occ_slots_panel.GetComponent<Text>().text = "" + Inventory.current_items;

        max_capacity_panel.GetComponent<Text>().text = "" + Inventory.capacity_max;
        capacity_panel.GetComponent<Text>().text = "" + Inventory.current_capacity;

    }


}