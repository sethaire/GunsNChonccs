using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{

    public InputActionAsset playerControls;
    private InputAction turning;


    public float sensitivity = 100f;
    [SerializeField] Transform cam;
    [SerializeField] float cameraRotation;
    [SerializeField] float cameraRotationLimit = 90f;

    public void Awake()
    {
        turning = playerControls.FindAction("Turning");
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        cameraRot();
    }

    public void cameraRot()
    {
        //The same as inputGetAxis, you get the horizontal & vertical axis and assign them to Mouse Y/X
        float mouseX = turning.ReadValue<Vector2>().x * sensitivity * Time.deltaTime;
        float mouseY = turning.ReadValue<Vector2>().y * sensitivity * Time.deltaTime * -1f;

        //Ngl I didnt write anything here about how these two lines work but its something with math...
        transform.Rotate(0f, mouseX, 0f);
        cameraRotation += mouseY;
        cameraRotation = Mathf.Clamp(cameraRotation, -cameraRotationLimit, cameraRotationLimit);
        cam.localEulerAngles = new Vector3(cameraRotation, 0f, 0f);

        cameraRotation += mouseY;
        //cam.localEulerAngles = new Vector3(cameraRotation, 0f, 0f);
    }
}
