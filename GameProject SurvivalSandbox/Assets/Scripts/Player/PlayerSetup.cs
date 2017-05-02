using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerSetup : NetworkBehaviour {

    [SerializeField]
    Behaviour[] disabled_components;


    private Camera spect_camera;
    // Init
    void Start() {

        if(!isLocalPlayer) {

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
    }

    void OnDisable() {

        if(spect_camera != null) {
            spect_camera.gameObject.SetActive(false);
        }
    }
}
