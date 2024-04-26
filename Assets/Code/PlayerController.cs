using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    private InputAction move;
    private InputAction look;
    
    private Vector3 velocity;

    private float cameraXRotation;

    //__________________________________________________________________

    public PlayerInput PlayerInput;
    public CharacterController Controller;
    public Transform Camera;

    public float speed = 10f;

    public float gravity = -9.8f;



    private void Start()
    {
        move = PlayerInput.actions.FindAction("Move");
        look = PlayerInput.actions.FindAction("look");
        cameraXRotation = Camera.rotation.eulerAngles.x;
    }

    private void Update()
    {
        Vector2 moveInput = move.ReadValue<Vector2>();

        Vector3 moveAmount = transform.forward * moveInput.y + transform.right * moveInput.x;

        velocity.x = moveAmount.x;
        velocity.y += gravity * Time.deltaTime;
        velocity.z = moveAmount.z;

        if (Controller.Move(velocity * speed * Time.deltaTime) == CollisionFlags.Below)
            velocity.y = 0;

        Vector2 lookInput = look.ReadValue<Vector2>();
        Vector3 cameraRotation = Camera.rotation.eulerAngles;
        cameraXRotation -= lookInput.y;

        cameraXRotation = Math.Clamp(cameraXRotation, 0, 90);

        cameraRotation.x = cameraXRotation;

        Camera.eulerAngles = cameraRotation;

        transform.Rotate(0, lookInput.x, 0);


    }

}