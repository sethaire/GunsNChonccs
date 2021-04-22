using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScriptV2 : MonoBehaviour
{

    [Header("Information")]
    public float health = 100;
    public float experience = 100;
    public bool isHostile = false;

    public GameObject tracker;
    private Transform target;

    NavMeshAgent agent;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        
    }

    void Update()
    {
        Hostile();
    }

    public void TakeDamage(float damage)
    {
        //When the enemy takes damage, itll become hostile towards the player
        health -= damage;
        isHostile = true;

        // & if the enemy has 0 or less health itll the destory and give the player experience.
        if (health <= 0)
        {
            tracker.GetComponent<LevelSystem>().expGain(experience);
            Destroy(gameObject);
        }
    }
    
    public void Hostile()
    {
        if(isHostile == true)
        {
            agent.SetDestination(target.position);
        }
    }
}
