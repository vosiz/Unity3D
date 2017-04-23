using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ItemType {

    UNKNOWN = 0,
    EMPTY,          // for an empty item
    FOUND,          // can be found in world, can be stored in inventory
    USABLE,         // can be added to toolbelt, can be used in hand, tool
    EQUIPABLE,      // can be worn
    HEAVY,          // can be picked up only with both hands
    VERY_HEAVY,     // as heavy but restricted to higher strength
};

public enum ItemFamily {

    UNKNOWN = 0,
    EMPTY,          // for an empty item
    COLLECTABLE,    // can be collected
    TOOL,           // crafted tool 
    GROWN,          // plant grown somewhere
    DERIVATIVE,     // can be obtained by collecting but mostly by processing
};

public struct InventoryItem {

    public int id;
    public string name;
    public ItemFamily item_family;
    public ItemType item_type;
    public string action_text;
    public int count;
    public float weight;
    //public ItemDatabaseId item_id;
};

public struct InventoryBackpackSlot {

    public bool free;
    public bool limited;

    public InventoryItem item;
};


public static class InventoryDatabase{


    public static int id = 0;

    private static Dictionary<string, float> weight_database = new Dictionary<string, float>();


    /* Registers weight of crafted item from blueprint*/
    public static void RegisterBlueprintWeight(string text, float weight) {

        if(!weight_database.ContainsKey(text)) {
            weight_database.Add(text, weight);
        }

    }

    /* Get registered weight*/
    public static float GetRegisteredWeight(string text) {

        float val = 0.0f;

        if (!weight_database.ContainsKey(text)) {
            weight_database.TryGetValue(text, out val);
            return val;
        }

        throw new System.Exception("Weight is not registered for item " + text);
    }

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
        //item.item_id = 0;

        return item;
    }

    /* Returns weight of item*/
    public static float FindWeight(string text) {

        switch(text) {

            case "Fiber plants":
                return 0.02f;
            case "Medium stone rock":
                return 0.5f;
            case "Wood stick":
                return 0.3f;


            case "Stone axe":
                return GetRegisteredWeight(text);

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
            case "Stone axe":
            case "Wood stick":
                return 1;

            default:
                throw new System.ArgumentException("Item family not found", "original");
        }
    }

    /* Create item*/
    private static void CreateItem(ItemFamily family, out InventoryItem item) {

        item = CreateEmptyItem();


        switch (family) {

            case ItemFamily.COLLECTABLE:
                item.action_text = "Collect:";
                item.item_family = family;
                item.item_type = ItemType.FOUND;
                break;

            case ItemFamily.TOOL:
                item.action_text = "Collect tool:";
                item.item_family = family;
                item.item_type = ItemType.USABLE;
                break;

            default:
                throw new System.ArgumentException("Item family not found", "original");
        }

    }


    /* Initialize item*/
    public static void InitItem(string text, out InventoryItem item) {

        ItemFamily item_family = ItemFamily.UNKNOWN;

        switch (text) {

            case "Fiber plants":
            case "Medium stone rock":
            case "Wood stick":
                item_family = ItemFamily.COLLECTABLE;
                break;

            case "Stone axe":
                item_family = ItemFamily.TOOL;
                break;

            default:
                throw new System.ArgumentException("Item name not found", "original");
        }

        CreateItem(item_family, out item);

        item.id = id;
        item.name = text;

        item.count = FindCount(text);
        item.weight = FindWeight(text);

        //item.item_id = FindItemId(text);

        id++;
    }
}
