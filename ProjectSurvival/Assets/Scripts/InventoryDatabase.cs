using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ItemType {

    UNKNOWN = 0,
    EMPTY,          // for an empty item
    FOUND,          // can be founded in world
};

public enum ItemFamily {

    UNKNOWN = 0,
    EMPTY,          // for an empty item
    COLLECTABLE,    // can be collected
    TOOL,           // crafted tool 
    GROWN,          // plant grown somewhere
    DERIVATIVE,     // can be obtained by collecting but mostly by processing something
};

public struct InventoryItem {

    public int id;
    public string name;
    public ItemFamily item_family;
    public ItemType item_type;
    public string action_text;
};

public struct InventoryBackpackSlot {

    public bool free;
    public bool limited;

    public InventoryItem item;
};


public static class InventoryDatabase{


    public static int id = 0;


    public static InventoryItem CreateEmptyItem() {

        InventoryItem item;

        item.id = 0;
        item.action_text = "";
        item.item_family = 0;
        item.item_type = 0;
        item.name = "";

        return item;
    }


    public static void CreateItem(ItemFamily family, out InventoryItem item) {

        item = CreateEmptyItem();


        switch (family) {

            case ItemFamily.COLLECTABLE:
                item.action_text = "Collect";
                item.item_family = family;
                item.item_type = ItemType.FOUND;
                Debug.Log("local log action " + item.action_text);
                break;

            default:
                throw new System.ArgumentException("Item family not found", "original");
        }

    }



    public static void InitItem(string text, out InventoryItem item) {

        Debug.Log("test");

        switch (text) {

            case "Grass":
                CreateItem(ItemFamily.COLLECTABLE, out item);
                Debug.Log("log action " + item.action_text);
                break;

            default:
                throw new System.ArgumentException("Item name not found", "original");
        }

        item.id = id;
        item.name = text;

        id++;
    }
}
