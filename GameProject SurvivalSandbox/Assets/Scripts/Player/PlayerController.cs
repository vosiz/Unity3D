using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]

public class PlayerController : MonoBehaviour {

    [SerializeField]
    private float speed = 5.0f;
    [SerializeField]
    private float mouse_sensitivity = 3.0f;

    private PlayerMotor motor;


    // Init
    void Start() {

        motor = GetComponent<PlayerMotor>();
    }


    // On tic update
    void Update() {

        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        float x_mouse = Input.GetAxisRaw("Mouse Y");
        float y_mouse = Input.GetAxisRaw("Mouse X");

        Vector3 x_mov = transform.right * x;
        Vector3 y_mov = transform.forward * y;
        Vector3 velocity = (x_mov + y_mov).normalized * this.speed;

        Vector3 mouse_move_x = new Vector3(x_mouse, 0f, 0f) * mouse_sensitivity;
        Vector3 mouse_move_y = new Vector3(0f, y_mouse, 0f) * mouse_sensitivity;

        motor.setVelocity(velocity);
        motor.setRotationX(mouse_move_y);
        motor.setRotationY(mouse_move_x);
    }
}
