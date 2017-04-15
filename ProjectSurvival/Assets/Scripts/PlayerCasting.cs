using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCasting : MonoBehaviour {

    public float distance;
    public Transform other;

    // Update is called once per frame
    void Update () {

        RaycastHit hit;
        Vector3 up = transform.TransformDirection(Vector3.forward);
        if (Physics.Raycast(transform.position, up, out hit))
        {
            distance = hit.distance;
        }

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