using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCasting : MonoBehaviour {

    static public float distance;
    static public bool casting_ready = false;

    static public Vector3 position;

    private Camera player_cam;
    public GameObject player;

    //Debug 
    [SerializeField]
    private Vector3 debug_player_pos;
    public float debug_distance;

    [SerializeField]
    public bool debug_ready;

    // Use this for initialization
    void Start() {

        player_cam = GetComponentInChildren<Camera>();
    }

    // updater
    void Update() {

        RaycastHit hit;


        //Debug.Log("Camera is: " + player_cam.ToString());
        debug_player_pos = player.transform.position;

        //Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f))

        //if (Physics.Raycast(player_cam.ScreenPointToRay(Input.mousePosition), out hit)) {
        //    distance = hit.distance;
        //    debug_distance = distance;
        //}

        if(Physics.Raycast(player_cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f)), out hit)) {

            distance = hit.distance;
            debug_distance = distance;
            position = hit.transform.position;
            casting_ready = true;
        }else {

            casting_ready = false;
            distance = 1000; // some big number
        }


        debug_ready = casting_ready;
    }
}
