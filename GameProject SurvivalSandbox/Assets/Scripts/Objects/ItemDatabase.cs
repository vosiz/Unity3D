using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// List of GameItem types
public enum GameItemType {

    /* BAD, default value ...*/
    UNKNOWN,

    COLLECTABLE,
}

/* List of attributes for GameItems*/
public enum GameItemAttribute {

    /* BAD, default value ...*/
    UNKNOWN,

    // Can be randomly spawn in map
    // f.e. Grass, Tree, Rock
    SPAWNABLE,

    // Can be picked up to inventory
    // f.e. Medium stone rock, Sticks, Pistol
    COLLECTABLE, 

    // Can be adde to same slot in inventory (until stack)
    // f.e. Grass, Arrows, Ammo 9mm
    STACKABLE,

    // Can be used as crafting material
    // f.e. Medium stone rock, Ammo 10mm, Sticks 
    CRAFTING_MATERIAL,

    // Can be processed to something else
    // f.e. Wood pellet, Stick, Iron ingot
    PROCESSABLE,

    // Can be used as fuel to flames
    // f.e. Crude oil, Firewood, Coal
    BURNABLE,

    // Can be crafted
    // f.e. Stone axe, Iron cog, Torch
    CRAFTABLE,

    // Cannot be added to inventory or to any store
    // f.e. Medium tree log, Car tire, Wall picture
    UNSTORABLE,

    // Can be moved only by equipping to one hand
    // f.e. Medium tree log, Car tire, Wall picture
    HEAVY_ITEM,

    // Can be moved only by using both hands (equip)
    // f.e. Large tree log, Car engine, Large stone rock
    VERY_HEAVY_ITEM,


}

/* Inventory item structure*/
public struct GameItem {

    /* Object ID*/
    public int id;
    /* Name of an object*/
    public string name;
    /* Count of items in object*/
    public int count;
    /* Item unit weight*/
    public float weight;
    /* Item total weight (count × weight)*/
    public float total_weight;
    /* Stack size - how many of these can be stored to same slot*/
    public int stack;

    /* Type of item*/
    public GameItemType type;
    /* Attributes of item*/
    public List<GameItemAttribute> attributes;
};

/* Inventory slot structure*/
public struct InventoryBackpackSlot {

    public bool free;
    public bool limited;

    public GameItem item;
};

public static class ItemDatabase {

    static int creation_id = 1;


    /* Returns count of item*/
    private static int FindItemCount(string name) {

        // check if there is mutation of this name (NAME###)
        if (TextUtilities.IsEndingDigit(name, 3)) {
            name = TextUtilities.TrimEnding(name, 3);
        }

        switch (name) {

            /* Atomic items*/

            /* Small count*/
            case "Grass":
                return Random.Range(2, 10);

            default:
                Errors.Error("Cannot find item count - " + name);
                return 0;
        }
    }


    /* Returns weight of item*/
    private static float FindItemWeight(string name) {

        // check if there is mutation of this name (NAME###)
        if (TextUtilities.IsEndingDigit(name, 3)) {
            name = TextUtilities.TrimEnding(name, 3);
        }

        switch (name) {

            case "Grass":
                return 0.02f;

            default:
                Errors.Error("Cannot find item weight - " + name);
                return 0.0f;
        }
    }


    /* Creates empty item*/
    private static void CreateEmptyItem(out GameItem item) {

        // Create empty item
        item.name = "Unknown";
        item.count = 0;
        item.type = GameItemType.UNKNOWN;
        item.weight = 0.0f;
        item.total_weight = 0.0f;
        item.stack = 0;
        item.attributes = new List<GameItemAttribute>();
        item.id = 0;
    }


    /* Tries to look up item in database*/
    private static bool FindItem(string item_name, out GameItem item) {

        // check if there is mutation of this name (NAME###)
        if(TextUtilities.IsEndingDigit(item_name, 3)) {
            item_name = TextUtilities.TrimEnding(item_name, 3);
        }

        // creates empty
        CreateEmptyItem(out item);

        // look up item name
        switch (item_name) {
            
            
            /* Collectables*/
            case "Grass":
                item.type = GameItemType.COLLECTABLE;
                break;


            //  tooo baaaaad
            default:
                return false;
        }

        // item was found
        return true;
    }

    /* Creates item from database*/
	public static void CreateItem(string name, out GameItem item) {

        // checks server created items
        if(name.EndsWith("(Clone)")) {
            name = name.Substring(0, name.LastIndexOf("(Clone)"));
        }

        // check item existance in database
        if(!FindItem(name, out item)) {

            Errors.Error("Item " + name + " not found in database");
        }


        // get weight of item
        item.weight = FindItemWeight(name);

        // get occurence count
        item.count = FindItemCount(name);

        // get stack size

        // mark creation id
        item.id = creation_id++;

        // add name
        item.name = name;

    }
}
