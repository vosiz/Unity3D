using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum GAME_SERVER_COMMAND {

    CREATE_MAP_OBJECT,
};



public static class GameServer {

    //static private bool CheckParameters(GAME_SERVER_COMMAND type, string[] words) {

    //    switch(type) {

    //        /* Parameters:  5
    //         - string       object name
    //         - int          count
    //         - Vector3 (3)  location
    //         */
    //        case GAME_SERVER_COMMAND.CREATE_MAP_OBJECT:

    //            if (words.Length <= 5) {

    //                if (words[0].Length < 2) return false;
    //                if ( Int32.Parse(words[1])) 

    //            } else return false;

    //            break;

    //        default:
    //            Errors.Warning("Unknown type:" + type.ToString());
    //    }


    //    return true;
    //}


    static public void Command(GAME_SERVER_COMMAND command, string parameters) {

        string[] split = parameters.Split(' ');

        switch (command) {

            /* Creates object on map
             Parameters:    2
             - string       object name
             - int          count 
             */
            case GAME_SERVER_COMMAND.CREATE_MAP_OBJECT:

                CreateMapObject(
                    split[0], 
                    new Vector3(Int32.Parse(split[1]), Int32.Parse(split[2]), Int32.Parse(split[3])), 
                    split.Length == 5 ? Int32.Parse(split[4]) : 1);

                break;

            default:
                Errors.Unimplemented(command.ToString());
                break;
        }
    }


    static private void CreateMapObject(string name, Vector3 location, int count = 1) {

        float radius_max = 10.0f; // in meters 

        bool randomize; // random spawn location of object(s)
        Vector3 spawn_loc = location;
        string object_path = "Objects/" + name;

        randomize = (location == Vector3.zero);

        for (int i = 0; i < count; i++) {

            if(randomize) {

                spawn_loc = new Vector3(
                    UnityEngine.Random.Range(-radius_max, radius_max),
                    UnityEngine.Random.Range(2, radius_max),
                    UnityEngine.Random.Range(-radius_max, radius_max)
                    );
            }

            GameObject obj = (GameObject)GameObject.Instantiate(Resources.Load(object_path), spawn_loc, Quaternion.identity);
        }



        //GameObject.Instantiate((GameObject)prefab, location, Quaternion.identity);

        //for (int y = 0; y < 5; y++) {
        //    for (int x = 0; x < 5; x++) {
        //        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        //        cube.AddComponent<Rigidbody>();
        //        cube.transform.position = new Vector3(x, y, 0);
        //    }
        //}
    }
}
