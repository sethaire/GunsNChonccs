using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class PlayerControllerV4 : MonoBehaviour
{
    [Header("InputActions")]
    public InputActionAsset playerControls;

    private InputAction movement;
    private InputAction turning;

    [Header("Modifier")]
    public float mouseSens = 100f;
    public float speedModifier = 1f;


    //Misc
    public Rigidbody rb;
    public Transform player;

    public Transform groundChecker;
    public float groundRad;
    public LayerMask groundlayer;


    private float speed = 3f;
    private float jumpforce = 200f;
    

    Camera cam = null;
    private float camRotation = 0;

    private void Awake()
    {

        movement = playerControls.FindAction("Movement");
        turning = playerControls.FindAction("Turning");

    }

    public void Start()
    {
        //rb = GetComponent<Rigidbody>();
        cam = Camera.main;

        //Lock the cursor & and cursor goes invisible
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

      
    }

    public void Update()
    {
        Move();
        Turn();
    }

    public void Move()
    {
        //Gets the input axis (Similiar to GetInputAxis Horizontal & Vertical)
        float x = movement.ReadValue<Vector2>().x;
        float z = movement.ReadValue<Vector2>().y;

        //Using transform.right & forward because it won't become stuck at those axis once the player rotates around.
        Vector3 direction = player.right * x + player.forward * z;

        rb.MovePosition(rb.position + direction * speed * speedModifier * Time.deltaTime);
    }

    public void Turn()
    {
        //The same as inputGetAxis, you get the horizontal & vertical axis and assign them to Mouse Y/X
        float mouseX = turning.ReadValue<Vector2>().x * mouseSens * Time.deltaTime;
        float mouseY = turning.ReadValue<Vector2>().y * mouseSens * Time.deltaTime;

        //Ngl I didnt write anything here about how these two lines work but its something with math...
        camRotation -= mouseY;
        camRotation = Mathf.Clamp(camRotation, -90, 90);

        //Camera rotates with the cursor
        cam.transform.localRotation = Quaternion.Euler(camRotation, 0, 0);
        player.Rotate(Vector3.up * mouseX);
    }

    public void Jump(InputAction.CallbackContext context)
    {
        //if context.started then the player will jump
        if(context.started)
        {
            rb.AddForce(player.up * jumpforce);
        }
    }

    private void OnEnable()
    {
        // So we can activate our inputs
        movement.Enable();
        turning.Enable();
    }

    private void OnDisable()
    {
        // So we can deactivate our inputs
        movement.Disable();
        turning.Disable();
    }


}
