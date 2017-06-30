using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerSetup : NetworkBehaviour {

    [SerializeField]
    Behaviour[] disabled_components;

    private Camera spect_camera;

    [SerializeField]
    private bool fps_view;

    // Init
    void Start() {

        this.fps_view = true;

        if (!isLocalPlayer) {

            for(int i = 0; i < disabled_components.Length; i++) {

                disabled_components[i].enabled = false;
            }
        }else {

            spect_camera = Camera.main;

            if(spect_camera != null) {

                // disables Spectate camera
                spect_camera.gameObject.SetActive(false);
            }

            
        }


        Inventory.initInventory(PlayerConfig.init_slots_count, PlayerConfig.max_inventory_slots, PlayerConfig.init_weight_cap);
    }

    // On clock tick
    void Update() {

        //// Change view from FSP style to RPG and vice versa
        //if(Input.GetButtonDown("ChangeView")) {

        //    this.fps_view = !this.fps_view;
        //    Debug.Log("view is fps: "+ this.fps_view.ToString());
        //}
    }

    void FixedUpdate() {

        
    }

    // On Disable
    void OnDisable() {

        if(spect_camera != null) {
            spect_camera.gameObject.SetActive(false);
        }
    }

    public bool getView() {

        return this.fps_view;
    }
}
