using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//public class Inventory : MonoBehaviour {
public static class Inventory {

    static public int maximum_backpack_items;
    static public int current_items;
    static public int total_backpack_slots;

    static public int free_backpack_slots;

    static public float current_capacity;
    static public float capacity_max;

    static public InventoryBackpackSlot[] items;


    static public void initInventory(int max_slots, int total_slots, float cap) {

        current_items = 0;
        maximum_backpack_items = max_slots;

        free_backpack_slots = max_slots;
        total_backpack_slots = total_slots;

        capacity_max = cap;
        current_capacity = cap;

        items = new InventoryBackpackSlot[total_slots];

        for(int i = 0; i < total_slots; i++) {

            items[i].item.id = 0;
            items[i].item.item_family = ItemFamily.EMPTY;
            items[i].item.item_type = ItemType.EMPTY;
            items[i].item.name = "";

            items[i].free = true;
            items[i].limited = (i >= max_slots);
        }
    }


    static public int addItem(InventoryItem item) {

        int taken = 0;


        // Check if can be picked up
        if (!canPickup(item)) return 0;

        taken = Inventory.addItemToInventory(item);

        return taken;
    }


    static private int addItemToInventory(InventoryItem item) {

        int can_be_added = 0;
        float total_weight = 0;


        can_be_added = Mathf.FloorToInt(current_capacity / item.weight);
        if (can_be_added > item.count) can_be_added = item.count;

        total_weight = can_be_added * item.weight;

        //Debug.Log("Can be added " +can_be_added);
        //Debug.Log("Total weight "+ total_weight);

        // if is already is in inventory add to slot
        for(int i = 0; i < total_backpack_slots; i++) {

            if(item.name.Equals(items[i].item.name)) {
                items[i].item.count += can_be_added;
                goto ADD_ITEM_END;
            }
        }


        // is not in inventory, check new place and store it
        for (int i = 0; i < total_backpack_slots; i++) {

            if(items[i].free) {

                items[i].item = item;
                items[i].item.count = can_be_added;
                items[i].free = false;

                current_items++;
                free_backpack_slots--;
                break;
            }
        }

        ADD_ITEM_END:
        current_capacity -= total_weight;
        return can_be_added;
    }

    static public bool canPickup(InventoryItem item) {

        // Check free slots
        if (free_backpack_slots == 0) {

            Debug.Log("not enought slots");
            return false;
        } 

        // Check capacity (for 1 unit, some can be added)
        if (current_capacity < item.weight) {

            Debug.Log("capacity problem: "+ current_capacity + " < "+ item.weight);
            return false;
        }

        return true;
    }


 //   //private int maximum_capacity;   // percent from maximum capacity

 //   //List<object> items;


 //   // Use this for initialization
 //   void Start () {

 //       maximum_items = 2;
 //       current_items = 0;
 //       //this.maximum_capacity = 80; // default

 //       //items = new List<object>();
 //   }
	
	//// Update is called once per frame
	//void Update () {

 //       free_slots = maximum_items - current_items;
 //   }

}