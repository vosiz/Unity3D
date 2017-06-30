using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//public class Inventory : MonoBehaviour {
public static class Inventory {

    static public int maximum_backpack_items;
    static public int current_items;
    static public int total_backpack_slots;

    static public int free_backpack_slots;

    static public float current_capacity;
    static public float capacity_max;

    static public InventoryBackpackSlot[] items;


    // inits inventory
    static public void initInventory(int max_slots, int total_slots, float cap) {

        current_items = 0;
        maximum_backpack_items = max_slots;

        free_backpack_slots = max_slots;
        total_backpack_slots = total_slots;

        capacity_max = cap;
        current_capacity = cap;

        items = new InventoryBackpackSlot[total_slots];

        // new slots
        for (int i = 0; i < total_slots; i++) {

            items[i].item.id = 0;
            items[i].item.type = GameItemType.UNKNOWN;
            items[i].item.name = "";

            items[i].free = true;
            items[i].limited = (i >= max_slots);
        }
    }

    // Tries to add an item to inventory
    static public int addItem(GameItem item) {

        // Check if can be picked up
        if (!canPickup(item)) return 0;

        return Inventory.addItemToInventory(item);
    }

    // Add item to inventory
    static private int addItemToInventory(GameItem item) {

        int can_be_added = 0;
        float total_weight = 0;


        can_be_added = Mathf.FloorToInt(current_capacity / item.weight);
        if (can_be_added > item.count) can_be_added = item.count;

        total_weight = can_be_added * item.weight;

        //Debug.Log("Can be added " +can_be_added);
        //Debug.Log("Total weight "+ total_weight);

        // if is already is in inventory add to slot
        for (int i = 0; i < total_backpack_slots; i++) {

            if (item.name.Equals(items[i].item.name)) {
                items[i].item.count += can_be_added;
                goto ADD_ITEM_END;
            }
        }


        // is not in inventory, check new place and store it
        for (int i = 0; i < total_backpack_slots; i++) {

            if (items[i].free) {

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

    // Checks if an item can be picked up
    static private bool canPickup(GameItem item) {

        // Check free slots
        if (free_backpack_slots == 0) {

            Debug.Log("not enought slots");
            return false;
        }

        // Check capacity (for 1 unit, some can be added)
        if (current_capacity < item.weight) {

            Debug.Log("capacity problem: " + current_capacity + " < " + item.weight);
            return false;
        }

        return true;
    }

    // Check inventory for duplicates
    static private int HasThis(string item_name, int item_count) {

        int packages = 0; // has this item × times

        for (int i = 0; i < maximum_backpack_items; i++) {

            // slot is not occupied
            if (items[i].free) continue;

            // slot item is not that item
            if (!items[i].item.name.Equals(item_name)) continue;

            if (items[i].item.count >= item_count) {

                packages = items[i].item.count;

            }

            break;
        }

        return packages;
    }

}