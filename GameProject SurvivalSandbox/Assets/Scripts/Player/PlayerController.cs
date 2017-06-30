using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]

public class PlayerController : MonoBehaviour {

    [SerializeField]
    private float speed;
    [SerializeField]
    private float mouse_sensitivity;
    [SerializeField]
    private float thrust_jump_speed;

    private PlayerMotor motor;


    // Init
    void Start() {

        this.speed = 5.0f;
        this.mouse_sensitivity = 3.0f;
        this.thrust_jump_speed = 1400f;

        motor = GetComponent<PlayerMotor>();
    }


    // On tic update
    void Update() {

        if (PlayerGuiController.show_backpack) return;

        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        float x_mouse = Input.GetAxisRaw("Mouse Y"); // weird... x / y...
        float y_mouse = Input.GetAxisRaw("Mouse X");

        Vector3 x_mov = transform.right * x;
        Vector3 y_mov = transform.forward * y;
        Vector3 velocity = (x_mov + y_mov).normalized * this.speed;

        float mouse_move_x = x_mouse * mouse_sensitivity;
        Vector3 mouse_move_y = new Vector3(0f, y_mouse, 0f) * mouse_sensitivity;

        Vector3 jump = Vector3.zero;

        // apply jumping and thruster jump
        if (Input.GetButton("Jump")) {

            // TODO: has thruster and is enought energy in thruster

            jump = Vector3.up * thrust_jump_speed;
        }

        // apply movement and camera rotation
        motor.setVelocity(velocity);
        motor.setRotationX(mouse_move_y);
        motor.setRotationY(mouse_move_x);
        motor.setJump(jump);

    }
}
