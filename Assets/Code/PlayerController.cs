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
    private InputAction interact;

    private Vector3 velocity;

    private float cameraXRotation;

    //______________________________________________________________

    public PlayerInput PlayerInput;
    public CharacterController Controller;
    public Transform Camera;

    public float speed = 10f;

    public float gravity = -9.8f; //m/s/s

    public interactable CurrentInteractable;


    // Start is called before the first frame update
    void Start()
    {
        move = PlayerInput.actions.FindAction("Move");
        look = PlayerInput.actions.FindAction("look");
        interact = PlayerInput.actions.FindAction("interact");
        cameraXRotation = Camera.rotation.eulerAngles.x;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveInput = move.ReadValue<Vector2>();

        Vector3 moveAmount = transform.forward * moveInput.y + transform.right * moveInput.x;

        velocity.x = moveAmount.x;
        velocity.y += gravity * Time.deltaTime;
        velocity.z = moveAmount.z;



        if (Controller.Move(velocity * speed * Time.deltaTime) == CollisionFlags.Below)
            velocity.y = 0;

        //holen einen Vector2 aus dem look
        Vector2 lookInput = look.ReadValue<Vector2>();
        Vector3 cameraRotation = Camera.rotation.eulerAngles;
        cameraXRotation -= lookInput.y;

        cameraXRotation = Mathf.Clamp(cameraXRotation, 0, 90);

        cameraRotation.x = cameraXRotation;

        Camera.eulerAngles = cameraRotation;

        transform.Rotate(0, lookInput.x, 0);

        //radiant (rad)

        //float angle = cameraXRotation * Mathf.Deg2Rad;
        //float z = Mathf.Cos(angle);
        //float y = Mathf.Sin(angle);

        //Vector3 cameraPosition = Camera.position;
        //cameraPosition.z = z;
        //cameraPosition.y = y;
        //Camera.position = cameraPosition;


        /*
        //hold
        interact.IsPressed();
        //pressed
        interact.WasPressedThisFrame();
        //released
        interact.WasReleasedThisFrame();
        */

        if (interact.WasPressedThisFrame() && CurrentInteractable != null)
            CurrentInteractable.Interact();

    }

    private void OnTriggerEnter(Collider other)
    {
        // Destroy(other.gameObject);
        //option 1: tag
        //if (other.CompareTag("Coin"))
        //{

        //}

        //option 2: component
        collectible collectable = other.GetComponent<collectible>();
        if (collectable != null)
            collectable.Collect();

        //interactable gedönsS
        interactable inter = other.GetComponent<interactable>();
        if (inter != null)
        {
            if (CurrentInteractable != null)
                CurrentInteractable.Unhighlight();

            CurrentInteractable = inter;
            CurrentInteractable.Highlight();
        }

    }

    private void OnTriggerExit(Collider other)
    {
        interactable inter = other.GetComponent<interactable>();
        if (inter != null)
        {
            inter.Unhighlight();
            CurrentInteractable = null;
        }
    }
}
