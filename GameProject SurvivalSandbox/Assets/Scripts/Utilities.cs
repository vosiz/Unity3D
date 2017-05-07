using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utilities {


    static public Transform GetChildrenByName(GameObject obj, string name) {

        // get all children components in object
        Transform[] ts = obj.transform.GetComponentsInChildren<Transform>(true);

        // find out the desired one
        foreach (Transform t in ts) {

            if (t.name == name) return t;
        }

        // nothing found
        return null;
    }

}
