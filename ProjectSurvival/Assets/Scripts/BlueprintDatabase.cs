using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Blueprint {

    public InventoryItem output;
    public InventoryItem[] components;
    public int component_count;
    public int can_craft;
    public int time_to_craft;   // in seconds;
    public float total_weight;
};

public static class BlueprintDatabase{

    private const int max_components = Config.blueprint_max_component;
    
    /* Creates an empty blueprint*/
    public static Blueprint CreateEmptyBlueprint() {

        Blueprint bp;

        bp.output = InventoryDatabase.CreateEmptyItem();

        bp.components = new InventoryItem[max_components];
        for (int i = 0; i < max_components; i++){

            bp.components[i] = InventoryDatabase.CreateEmptyItem();
        }

        bp.component_count = max_components;
        bp.can_craft = 0;
        bp.time_to_craft = 0;
        bp.total_weight = 0.0f;

        return bp;
    }

    /* Gets total weight of blueprint output item*/
    public static float GetBlueprintOutputWeight(Blueprint output_item) {

        float weight = 0.0f;

        foreach(InventoryItem item in output_item.components) {

            weight += item.weight;
        }

        return weight;
    }

    /* Creates components as items*/
    static private void CreateComponents(out Blueprint bp, int[] counts, string[] names, int comp_count) {

        bp = CreateEmptyBlueprint();

        for(int i = 0; i < comp_count; i++) {

            InventoryDatabase.InitItem(names[i], out bp.components[i]);
            bp.components[i].count = counts[i];
        }
    }

    /* Initialize blueprint*/
    public static void InitBlueprint(string text, out Blueprint bp) {

        int component_count = 0;
        int craft_time = 0;
        string[] names;
        int[] counts;

        bp = CreateEmptyBlueprint();

        switch (text) {

            case "Stone axe":
                craft_time = 5;
                component_count = 3;
                counts = new int[] { 1, 1, 5 };
                names = new string[] {
                    "Wood stick",
                    "Medium stone rock",
                    "Fiber plants"
                };
                break;

            default:
                throw new System.ArgumentException("Item name not found", "original");
        }

        // create components
        CreateComponents(out bp, counts, names, component_count);

        // Create output item
        InventoryDatabase.InitItem(text, out bp.output);
        
        // other parameters of blueprint
        bp.component_count = component_count;
        bp.time_to_craft = craft_time;
        bp.total_weight = GetBlueprintOutputWeight(bp);
        InventoryDatabase.RegisterBlueprintWeight(text, bp.total_weight);
    }

}
