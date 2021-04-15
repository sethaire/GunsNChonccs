using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class GunScriptV1 : MonoBehaviour
{
    public GameObject projectile;
    [SerializeField] private float shootForce = 100f;
    void Start()
    {
 
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    public void shooting(InputAction.CallbackContext context)
    { 
        if(context.started)
        {
            GameObject shot = GameObject.Instantiate(projectile, transform.position, transform.rotation);
            shot.GetComponent<Rigidbody>().AddForce(transform.forward * shootForce);
        }
    }
}
