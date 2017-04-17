using System.Collections;
using System.Collections.Generic;
using UnityEngine;





//public class Inventory : MonoBehaviour {
public static class Inventory {

    static public int maximum_backpack_items;
    static public int current_items;
    static public int total_backpack_slots;

    static public int free_backpack_slots;

    static public InventoryBackpackSlot[] items;


    static public void initInventory(int max_slots, int total_slots) {

        current_items = 0;
        maximum_backpack_items = max_slots;

        free_backpack_slots = max_slots;
        total_backpack_slots = total_slots;

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


    static public bool addItem(InventoryItem item) {

        if (free_backpack_slots == 0) return false;

        Inventory.findFreeSlot(item);

        current_items++;
        free_backpack_slots--;

        return true;
    }


    static private void findFreeSlot(InventoryItem item) {

        for(int i = 0; i < total_backpack_slots; i++) {

            if(items[i].free) {

                items[i].item = item;
                break;
            }
        }
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