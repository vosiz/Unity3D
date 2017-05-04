using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class PlayerMotor : MonoBehaviour {

    [SerializeField]
    private Camera camera;

    private Vector3 velocity;
    private Vector3 rotation_x;
    private Vector3 rotation_y;
    private Vector3 jump;

    private Rigidbody rb;

    // Init
    void Start() {

        this.velocity   = Vector3.zero;
        this.rotation_x = Vector3.zero;
        this.rotation_y = Vector3.zero;
        this.jump       = Vector3.zero;

        rb = GetComponent<Rigidbody>();
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
            camera.transform.Rotate(-rotation_y);
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
    public void setRotationY(Vector3 rotation) {

        this.rotation_y = rotation;
    }

    // Jump movement
    public void setJump(Vector3 jump) {

        this.jump = jump;
    }
}
