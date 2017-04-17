using System.Collections;
using System.Collections.Generic;
using UnityEngine;





public class PlayerCasting : MonoBehaviour
{

    static public float distance;

    public float debug_distance;
    public GameObject player;

    private Vector3 player_pos;


	// Use this for initialization
	void Start () {

	}

    // updater
    void Update() {

        RaycastHit hit;
        //RaycastHit hitInfo = new RaycastHit();
        player_pos = player.transform.position;

        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit)){
            distance = hit.distance;
            debug_distance = distance;
        }
    }


    public float GetDistance() {
        return distance;
    }
}




//static var DistanceFromTarget : float;

//var ToTarget : float;

//function Update()
//{

//    var hit : RaycastHit;

//    if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), hit))
//    {
//        ToTarget = hit.distance;
//        DistanceFromTarget = ToTarget;
//    }
//}