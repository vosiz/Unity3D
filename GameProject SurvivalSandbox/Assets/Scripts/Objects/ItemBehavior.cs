using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public struct TOOLTIP {

    /* An item id*/
    public int id;
    /* Show action to be performed on tooltip showup*/
    public string action;
    /* Name of an tooltiped object*/
    public string object_name;
    /* How many objects contains tooltiped*/
    public int object_count;
    /* Informariont of tooltiped*/
    public string info;

};



[RequireComponent(typeof(Item))]

public class ItemBehavior : MonoBehaviour {

    private TOOLTIP tp;

    private bool init = false; // for databse fetching

    //private string object_name;
    //private GameItem item;

    private Item item_object;

    private bool pointed; // They are wathing me!

    //debug
    //[SerializeField]
    //private bool show_tooltip;

    [SerializeField]
    private float dist;

    // Use this for initialization
    void Start () {

    }


    void Update() {

        if(this.item_object == null) {

            item_object = this.GetComponent<Item>();
            return; // for to be sure
        }

        // memory and time saving
        // created only once
        // created after onMouseOver event
        if (!init && PlayerCasting.casting_ready) { // fetch item info from db once

            this.tp.id = item_object.GetItem().id;
            this.tp.object_name = item_object.GetItem().name;
            this.tp.object_count = this.item_object.GetItem().count;

            this.tp.action = "Collect";
            this.tp.info = "Example text";

            init = true;
        }

        // check aiming at object
        this.pointed = (this.transform.position == PlayerCasting.position);

        if (this.pointed) {

            Debug.Log("Pointing at item #" + this.item_object.GetItem().id);
        }


        if (PlayerCasting.casting_ready && this.pointed) {

            dist = PlayerCasting.distance; // player distance from me (the object)

            // show action only in within range
            this.ShowAction(
                PlayerCasting.distance < PlayerConfig.action_display_distance);

            // show tooltip only in within range
            this.ShowTooltip(
                PlayerCasting.distance < PlayerConfig.tooltip_display_distance);

            // Checks pickuping
            PickUp();

        }

    }
	
    // Enables/disables action text display
    void ShowAction(bool show_enabled) {

        if(show_enabled) {

            PlayerGuiController.show_action = true;
            PlayerGuiController.tooltip = tp;


        } else {

            PlayerGuiController.show_action = false;

        }
    }

    // Enables/disables tooltip display
    void ShowTooltip(bool show_enabled) {

        if(show_enabled) {

            PlayerGuiController.tooltip = tp;
            PlayerGuiController.show_tooltip = true;

        } else {

            PlayerGuiController.show_tooltip = false;
        }
    }


    public void PickUp() {

        if(PlayerStatus.interaction) {

            if(Inventory.addItem(this.item_object.GetItem()) == this.item_object.GetItem().count ) { // all hase been taken

                //destroy item
                transform.root.gameObject.SetActive(false);
            }

            
        }
    }


	// OnMouseOver event
	//void OnMouseOver () {

 //       // memory and time saving
 //       // created only once
 //       // created after onMouseOver event
 //       if(!init) { // fetch item info from db once

 //           object_name = transform.root.name;

 //           ItemDatabase.CreateItem(this.object_name, out this.item);

 //           this.tp.object_name = object_name;
 //           this.tp.action = "Collect";
 //           this.tp.object_count = this.item.count;

 //           this.tp.info = "Example text";

 //           init = true;
 //       }

 //       dist = PlayerCasting.distance;

 //       // show action only in within range
 //       this.ShowAction(
 //           PlayerCasting.distance < PlayerConfig.action_display_distance);

 //       // show tooltip only in within range
 //       this.ShowTooltip(
 //           PlayerCasting.distance < PlayerConfig.tooltip_display_distance);
 //   }

    // On mouse out
    //void OnMouseExit() {

    //    this.ShowAction(false);
    //    this.ShowTooltip(false);
    //}

}
