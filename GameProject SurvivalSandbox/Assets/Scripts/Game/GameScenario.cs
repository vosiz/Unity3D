using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GAME_SCENARIO{

    /* Spawns grass, stones and sticks on map*/
    GAME_SCENARIO_001,
};

public class GameScenario : MonoBehaviour {
    
    // This is important...
    private const GAME_SCENARIO scenario_number = GAME_SCENARIO.GAME_SCENARIO_001;

    public GameObject floor;
    public GameObject sun;

	// Use this for initialization
	void Start () {

        switch(scenario_number) {

            case GAME_SCENARIO.GAME_SCENARIO_001:

                // Create collectable objects
                GameServer.Command(GAME_SERVER_COMMAND.CREATE_MAP_OBJECT, "Stick 0 0 0 5");
                GameServer.Command(GAME_SERVER_COMMAND.CREATE_MAP_OBJECT, "MediumStoneRock 0 0 0 4");
                GameServer.Command(GAME_SERVER_COMMAND.CREATE_MAP_OBJECT, "Grass 0 0 0 10");

                break;

            default:
                throw new System.Exception("Unknown scenario number!");
        }

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
