using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class PlayerControllerV3 : MonoBehaviour
{
    [Header("InputActions")]
    public InputActionAsset playerControls;

    private InputAction shootKey;
    private InputAction reload;

    private InputAction movement;
    private InputAction turning;

    public float mouseSens = 100f;


    //Misc
    Rigidbody rb;
    private float speed = 3f;

    private Camera cam = null;
    private float camRotation = 0;

    private void Awake()
    {
        //var playerActionMap = playerControls.FindActionMap("PlayerInputs");


        shootKey = playerControls.FindAction("ShootKey");
        movement = playerControls.FindAction("Movement");
        turning = playerControls.FindAction("Turning");
        reload = playerControls.FindAction("Interact");

    }

    public void Start()
    {
        rb = GetComponent<Rigidbody>();
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
        Vector3 direction = transform.right * x + transform.forward * z;

        rb.MovePosition(rb.position + direction * speed * Time.deltaTime);
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
        transform.Rotate(Vector3.up * mouseX);
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

    public void reloaded(InputAction.CallbackContext context)
    {
      if(context.started)
      {
            Debug.Log("reloaded key used");
      }
    }

}
