using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public static class ItemDatabase {

    private static bool sprites_loaded = false;

    private static Sprite[] sprites;


    /* Looks for sprite in resource array*/
    static private Sprite findSprite(string name) {

        foreach(Sprite sprite in sprites) {

            if (sprite.name == name) return sprite;
        }

        return null;
    }



    /* Get sprite by name*/
    static public Sprite GetSprite(string item_name) {

        if (!sprites_loaded) {

            sprites = Resources.LoadAll<Sprite>("Sprites");
            sprites_loaded = true;
        } 
        //else if (sprites != null) Debug.Log("good " + sprites.Length);


        switch (item_name) {

            case "Fiber plants":
                return findSprite("fiberplants");
            case "Medium stone rock":
                return findSprite("mediumstonerock");
            case "Wood stick":
                return findSprite("woodstick");


            // TODO: return default
            default:
                return null;
        }
    }

}
