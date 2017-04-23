using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class GameManager : MonoBehaviour{

    static public bool fsp_controls_enabled; // allows fps controlling and mouse look

    public static bool backpack_open_state;
    public static bool crafting_open_state;

    public GameObject fps_controller; // fps controller
    public Texture2D cursor_texture;

    private Vector2 spot = Vector2.zero;
    private Vector2 mouse;
    int w, h;

    /* Init*/
    void Start() {

        fsp_controls_enabled = true;
        w = 32;
        h = 32;
        Cursor.visible = false;

        GameScenario.InitGameScenario();
    }


    /* OnTick*/
    void Update() {

        //controller.GetComponent<FirstPersonController>().Set
        fps_controller.GetComponent<FirstPersonController>().enabled = fsp_controls_enabled;
        Cursor.visible = !fsp_controls_enabled;
        Cursor.lockState = CursorLockMode.None;
    }


    //void OnGUI() {
    //    //GUI.DrawTexture(new Rect(mouse.x - (w / 2), mouse.y - (h / 2), w, h), cursor_texture);
    //}

    ///* On mouse enter*/
    //void OnMouseEnter() {

    //    Cursor.SetCursor(cursor_texture, spot, CursorMode.Auto);
    //}


    ///* On mouse exit*/
    //void OnMouseExit() {

    //    Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    //}
}
