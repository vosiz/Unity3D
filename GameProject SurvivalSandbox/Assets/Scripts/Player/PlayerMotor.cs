using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(PlayerSetup))]

public class PlayerMotor : MonoBehaviour {

    [SerializeField]
    private Camera camera;
    private Vector3 camera_def_pos;

    private PlayerSetup p_setup;

    private Vector3 velocity;
    private Vector3 rotation_x;
    private float rotation_y;
    private float current_rotation_y;
    private Vector3 jump;

    [SerializeField]
    private float camera_rotation_limit;

    private Rigidbody rb;


    // Init
    void Start() {

        this.velocity   = Vector3.zero;
        this.rotation_x = Vector3.zero;
        this.rotation_y = 0f;
        this.jump       = Vector3.zero;

        this.rb = GetComponent<Rigidbody>();

        this.camera_rotation_limit = 78f;
        this.current_rotation_y = 0f;

        this.p_setup = GetComponent<PlayerSetup>();

        this.camera_def_pos = camera.transform.position;
    }


    // Tick update
    void FixedUpdate() {

        this.makeMovement();
        this.makeRotation();
    }


    // Performs rotation
    private void makeRotation() {

        rb.MoveRotation(rb.rotation * Quaternion.Euler(rotation_x));

        if(camera != null) {

            this.current_rotation_y -= this.rotation_y;
            this.current_rotation_y = Mathf.Clamp(this.current_rotation_y, -camera_rotation_limit, camera_rotation_limit);

            camera.transform.localEulerAngles = new Vector3(this.current_rotation_y, 0f, 0f);

            //if(!p_setup.getView()) {

            //    //camera.transform.position = new Vector3(3, 3, 3);
            //    camera.transform.position = new Vector3(
            //        camera_def_pos.x + 0f,
            //        camera_def_pos.y + 3f,
            //        camera_def_pos.z + -3f
            //        );
            //} else {
            //    //camera.transform.position = camera_def_pos;
            //}
        }
    }


    // Performs movement
    private void makeMovement() {

        // moves on floor
        if(this.velocity != Vector3.zero) {
            rb.MovePosition(rb.position + this.velocity * Time.fixedDeltaTime);
        }

        // jump perform
        if(jump != Vector3.zero) {

            rb.AddForce(this.jump * Time.fixedDeltaTime, ForceMode.Acceleration);
        }
        
    }


    // Make movement
    public void setVelocity(Vector3 velocity) {

        this.velocity = velocity;
    }


    // Rotation movement
    public void setRotationX(Vector3 rotation) {

        this.rotation_x = rotation;
    }

    // Rotation movement
    public void setRotationY(float rotation) {

        this.rotation_y = rotation;
    }

    // Jump movement
    public void setJump(Vector3 jump) {

        this.jump = jump;
    }
}
