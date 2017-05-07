using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCasting : MonoBehaviour {

    static public float distance;


    public GameObject player;


    //Debug 
    //[SerializeField]
    //private Vector3 player_pos;
    //public float debug_distance;


    // Use this for initialization
    void Start() {

    }

    // updater
    void Update() {

        RaycastHit hit;
        Camera player_cam = GetComponentInChildren<Camera>();

        //Debug.Log("Camera is: " + player_cam.ToString());
        //player_pos = player.transform.position;

        if (Physics.Raycast(player_cam.ScreenPointToRay(Input.mousePosition), out hit)) {
            distance = hit.distance;
        }
    }
}
