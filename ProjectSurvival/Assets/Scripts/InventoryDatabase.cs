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
    public int count;
    public float weight;
};

public struct InventoryBackpackSlot {

    public bool free;
    public bool limited;

    public InventoryItem item;
};


public static class InventoryDatabase{


    public static int id = 0;


    /* Makes empty item*/
    public static InventoryItem CreateEmptyItem() {

        InventoryItem item;

        item.id = 0;
        item.action_text = "";
        item.item_family = 0;
        item.item_type = 0;
        item.name = "";
        item.count = 0;
        item.weight = 0;

        return item;
    }


    /* Returns weight of item*/
    public static float FindWeight(string text) {

        switch(text) {

            case "Fiber plants":
                return 0.02f;
            case "Medium stone rock":
                return 0.3f;
            case "Wood stick":
                return 0.1f;

            default:
                throw new System.ArgumentException("Item family not found", "original");
        }
    }

    /* Returns count in item*/
    public static int FindCount(string text) {

        switch (text) {

            case "Fiber plants":
                return Random.Range(1, 6);

            case "Medium stone rock":
            case "Wood stick":
                return 1;

            default:
                throw new System.ArgumentException("Item family not found", "original");
        }
    }

    /* Create item*/
    public static void CreateItem(ItemFamily family, out InventoryItem item) {

        item = CreateEmptyItem();


        switch (family) {

            case ItemFamily.COLLECTABLE:
                item.action_text = "Collect";
                item.item_family = family;
                item.item_type = ItemType.FOUND;
                break;

            default:
                throw new System.ArgumentException("Item family not found", "original");
        }

    }


    /* Initialize item*/
    public static void InitItem(string text, out InventoryItem item) {

        switch (text) {

            case "Fiber plants":
            case "Medium stone rock":
            case "Wood stick":
                CreateItem(ItemFamily.COLLECTABLE, out item);
                break;

            default:
                throw new System.ArgumentException("Item name not found", "original");
        }

        item.id = id;
        item.name = text;

        item.count = FindCount(text);
        item.weight = FindWeight(text);

        id++;
    }
}
