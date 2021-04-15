using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    public float damage = 20;
    void Start()
    {
        Destroy(gameObject, 3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag ("Cube"))
        {
            collision.gameObject.GetComponent<EnemyScriptV1>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }

}
