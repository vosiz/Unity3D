using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerGui : MonoBehaviour {

    //public GameObject tooltip;

    private GameObject canvas;
    private GameObject pgui;

    private Transform crosshair;

    private Transform tooltip;
    private Transform tp_action_text;
    private Transform tp_info_text;

    private Transform action_text;
    private Transform backpack;

    // debug
    [SerializeField]
    private bool showme;

    // Use this for initialization
    void Start () {

        // Find primal GUI elements
        canvas = GameObject.FindWithTag("Canvas");
        pgui = GameObject.FindWithTag("PlayerGui");

        // Hide cursor
        Cursor.visible = false;

        // Get components of tooltip and hide them all
        tooltip = Utilities.GetChildrenByName(pgui, "Tooltip");
        tp_action_text = Utilities.GetChildrenByName(tooltip, "ActionText");
        tp_info_text = Utilities.GetChildrenByName(tooltip, "TargetInfoText");
        PlayerGuiController.show_tooltip = false;

        // Get action text and hide it
        action_text = Utilities.GetChildrenByName(pgui, "ActionText");

        // Show crosshair
        crosshair = Utilities.GetChildrenByName(pgui, "Crosshair");
        crosshair.gameObject.SetActive(true);

        // Hide backpack GUI
        backpack = Utilities.GetChildrenByName(pgui, "Backpack");
        PlayerGuiController.show_backpack = false;
    }
	

	// Update is called once per frame
	void Update () {

        // show action_text on mouse over
        if (PlayerGuiController.show_action) {

            action_text.gameObject.GetComponent<Text>().text = PlayerGuiController.tooltip.action;
            action_text.gameObject.SetActive(true);
        }else {

            action_text.gameObject.SetActive(false);
        }

        // tool tip display condition
        //showme = PlayerGuiController.show_tooltip;
        if (PlayerGuiController.show_tooltip && PlayerGuiController.show_tooltip_btn) {

            string action = null;

            action = "#" + PlayerGuiController.tooltip.id + " ";

            // set action text (action, object, count)
            action += PlayerGuiController.tooltip.action + " " + TextUtilities.CorrectSuffix(PlayerGuiController.tooltip.object_name);

            // check count and edit eventually action text
            if (PlayerGuiController.tooltip.object_count > 1) {

                action += " (" +
                    (PlayerGuiController.tooltip.object_count) + ")";
            }

            // save action text to Text component
            tp_action_text.gameObject.GetComponent<Text>().text = action;

            // set info text
            tp_info_text.gameObject.GetComponent<Text>().text = PlayerGuiController.tooltip.info;

            // show tooltip
            tooltip.gameObject.SetActive(true);

        } else {

            tooltip.gameObject.SetActive(false);
        }


        // show backpack
        if (PlayerGuiController.show_backpack) {

            backpack.gameObject.SetActive(true);
            Cursor.visible = true;

        } else {
            backpack.gameObject.SetActive(false);
            Cursor.visible = false;
        }




        PlayerGuiController.show_action = false;
        PlayerGuiController.show_tooltip = false;
    }




}
