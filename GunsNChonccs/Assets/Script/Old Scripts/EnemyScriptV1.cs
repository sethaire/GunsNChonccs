using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScriptV1 : MonoBehaviour
{
    [Header("Information")]
    public float health = 100;
    public float experience = 100;
    public bool isHostile = false;

    public GameObject targ = null;

    public GameObject Tracker;
    

    void Awake()
    {
    }

    public void Update()
    {
        Hostile();
    }

    public void TakeDamage(float damage)
    {
        //When the enemy takes damage, itll become hostile towards the player
        health -= damage;
        if(isHostile == false)
        {
            isHostile = true;
        }

        // & if the enemy has 0 or less health itll the destory and give the player experience.
        if(health <= 0)
        {
            Tracker.GetComponent<LevelSystem>().expGain(experience);
            Destroy(gameObject);
        }
    }

    public void Hostile()
    {
        if(isHostile == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, targ.transform.position, 3);
        }
    }
}
