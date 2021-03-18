using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class PlayerControllerV2 : MonoBehaviour
{

    [Header("Player inputs")]
    public InputAction movement;
    [SerializeField] private InputAction turning;

    [SerializeField] private float speed = 3f;
    public float mouseSens = 100f;

    [Header("Misc")]
    Rigidbody rb;
    private Camera cam = null;
    private float camRotation = 0;



    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cam = Camera.main;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    void OnEnable()
    {
        //So we can activate our inputs
        movement.Enable();
        turning.Enable();
    }

    void OnDisable()
    {
        //So we can disable our inputs
        movement.Disable();
        turning.Disable();
    }
    void Update()
    {
        //This should be self explanatory right now.
        Move();
        Turn();
    }
    public void Move()
    {
        //Gets the input axis (Similiar to GetInputAxis Horizontal & Vertical)
        float x = movement.ReadValue<Vector2>().x;
        float z = movement.ReadValue<Vector2>().y;

        //Using transform.right & forward because it won't be stuck at those axis when the player rotates around.
        Vector3 direction = transform.right * x + transform.forward * z;

        //Moving
        rb.MovePosition(rb.position + direction * speed * Time.deltaTime);
    }

    public void Turn()
    {
        //The same as inputGetAxis, you get the horizontal & vertical axis and assign them to Mouse Y/X
        float mouseX = turning.ReadValue<Vector2>().x * mouseSens * Time.deltaTime;
        float mouseY = turning.ReadValue<Vector2>().y * mouseSens * Time.deltaTime;

        //Honestly, I forgot what the hell this do, but it works.
        camRotation -= mouseY;
        camRotation = Mathf.Clamp(camRotation, -90, 90);

        //Camera rotates with the cursor or some shit.
        cam.transform.localRotation = Quaternion.Euler(camRotation, 0, 0);
        transform.Rotate(Vector3.up * mouseX);
    }
}
