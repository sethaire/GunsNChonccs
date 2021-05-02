using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class GunScriptV1 : MonoBehaviour
{
    public GameObject projectile;
    public Transform gunTip;
    [SerializeField] private float shootForce = 100f;
    void Start()
    {
 
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    public void Shooting(InputAction.CallbackContext context)
    { 
        if(context.started)
        {
            GameObject shot = GameObject.Instantiate(projectile, gunTip.position, gunTip.rotation);
            shot.GetComponent<Rigidbody>().AddForce(gunTip.forward * shootForce);
        }
    }
}
