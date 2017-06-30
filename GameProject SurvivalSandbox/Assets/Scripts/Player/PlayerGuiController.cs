using System.Collections;
using System.Collections.Generic;
using UnityEngine;




static public class PlayerGuiController {

    static public TOOLTIP tooltip;

    static public bool show_action      = false;

    static public bool show_tooltip     = false;
    static public bool show_tooltip_btn = false;

    static public bool show_backpack    = false;
    


    static public void ToggleShowBackpack() {
        show_backpack = !show_backpack;
    }
}
