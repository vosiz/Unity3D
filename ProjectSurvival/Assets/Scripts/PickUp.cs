using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour {

    public GameObject inventory;
    public GameObject inventory_panel;
    public int free_slots;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        free_slots = Inventory.free_backpack_slots;
	}
}
