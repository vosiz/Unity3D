using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameScenario {

    private static string[] starting_bluprints;

    public const int backpack_max_size = 40;
    public const int backpack_init_size = 4;
    public const float backpack_capacity_init_size = 3.0f;


    public static void InitGameScenario() {

        // blueprints
        starting_bluprints = new string[] {

            "Stone axe"
        };

        // inventory

    }


    public static string[] GetStartingBlueprints() {

        return starting_bluprints;
    }
}
