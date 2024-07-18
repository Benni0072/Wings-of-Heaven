using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    private InputAction move;
    private InputAction look;
    private InputAction interact;
    private InputAction pause;

    private Vector3 velocity;

    private float cameraXRotation;

    //______________________________________________________________

    public PlayerInput PlayerInput;
    public CharacterController Controller;
    public Transform Camera;
    public Animator Animator;
    public FootstepPlayer Footsteps;

    public float speed = 10f;

    public float RotationSpeed = 0.2f;

    public float gravity = -9.8f; //m/s/s


    //______________________________________________________________________
    public PauseMenu pauseMenu;
    //______________________________________________________________________

    public interactable CurrentInteractable;
    public collectible CurrentCollectible;


    // Start is called before the first frame update
    void Start()
    {
        move = PlayerInput.actions.FindAction("Move");
        look = PlayerInput.actions.FindAction("look");
        interact = PlayerInput.actions.FindAction("interact");
        cameraXRotation = Camera.rotation.eulerAngles.x;
        //___________________________________________________________________
        pause = PlayerInput.actions.FindAction("Pause");
        //___________________________________________________________________
    }

    // Update is called once per frame
    void Update()
    {

        Animator.SetFloat("speed", velocity.magnitude);

        Vector2 moveInput = move.ReadValue<Vector2>();

        Vector3 moveAmount = transform.forward * moveInput.y + transform.right * moveInput.x;

        velocity.x = moveAmount.x;
        velocity.y += gravity * Time.deltaTime;
        velocity.z = moveAmount.z;





        if (Controller.Move(velocity * speed * Time.deltaTime) == CollisionFlags.Below)
            velocity.y = 0;

//__________________________________________________________________________________________________________
        //holen einen Vector2 aus dem look
        Vector2 lookInput = look.ReadValue<Vector2>();
        Vector3 cameraRotation = Camera.rotation.eulerAngles;
        cameraXRotation -= lookInput.y;

        cameraXRotation = Mathf.Clamp(cameraXRotation, 0, 90);

        cameraRotation.x = cameraXRotation;

        Camera.eulerAngles = cameraRotation;
        
        //per default wird Space.Selfe benutzt (also die lokale Achse)
        Camera.Rotate(0, lookInput.x, 0, Space.World);

        if (moveInput != Vector2.zero)
        {
            Vector3 cameraForward = Camera.forward; //wert kopiert
            cameraForward.y = 0;
            cameraForward.Normalize();

            transform.forward = Vector3.Lerp(transform.forward, cameraForward, RotationSpeed);
        }
//____________________________________________________________________________________________________________

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



        //_____________________________________________________________________________
        if (pause.WasPressedThisFrame() && pauseMenu != null)
            pauseMenu.PauseGame();
        //_____________________________________________________________________________

        Camera.position = transform.position;

        if (interact.WasPerformedThisFrame() && CurrentCollectible != null)
        {
            Animator.SetTrigger("collect");
            CurrentCollectible.Invoke("Collect", 0.5f);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        // Destroy(other.gameObject);
        //option 1: tag
        //if (other.CompareTag("Coin"))
        //{

        //}

        //option 2: component
        //collectible collectable = other.GetComponent<collectible>();
       // if (collectable != null)
         //   collectable.Collect();

        collectible collectable = other.GetComponent<collectible>();
        if (collectable!= null)
        {
            if (CurrentCollectible != null)
                CurrentCollectible.Unhighlight();

            CurrentCollectible = collectable;
            CurrentCollectible.Highlight();
        }

        //interactable gedönsS
        interactable inter = other.GetComponent<interactable>();
        if (inter != null)
        {
            if (CurrentInteractable != null)
                CurrentInteractable.Unhighlight();

            CurrentInteractable = inter;
            CurrentInteractable.Highlight();
        }

        if (other.CompareTag(Footsteps.WoodSound))
        {
            Footsteps.FootstepInstance.setParameterByNameWithLabel("Untergründe", Footsteps.WoodSound);
        }

    }

    private void OnTriggerExit(Collider other)
    {
        interactable inter = other.GetComponent<interactable>();
        if (inter != null)
        {
            CurrentInteractable = null;
            inter.Unhighlight();
        }

        collectible collectable = other.GetComponent<collectible>();
        if (collectable != null)
        {
            CurrentCollectible = null;
            collectable.Unhighlight();
        }

        if (other.CompareTag(Footsteps.WoodSound))
        {
            Footsteps.FootstepInstance.setParameterByNameWithLabel("Untergründe", Footsteps.DefaultSound);
        }
    }

    public void DisableInput(bool disabled)
    {
        PlayerInput.enabled = !disabled; //invert bool
    }
}
