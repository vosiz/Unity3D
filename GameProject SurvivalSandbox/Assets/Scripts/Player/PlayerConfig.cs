using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerConfig {

    // Player casting and interaction
    [Header("Tooltips settings")]
    public const float tooltip_display_distance     = 4.0f;
    public const float action_display_distance      = 3.0f;
    public const float interaction_distance         = 3.0f;

    // Inventory setup
    [Header("Ïnventory")]
    public const int max_inventory_slots    = 40;
    public const int init_slots_count       = 4;
    public const float init_weight_cap      = 3.0f;
}
