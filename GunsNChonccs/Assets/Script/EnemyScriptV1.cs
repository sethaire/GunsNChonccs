using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScriptV1 : MonoBehaviour
{
    public float health = 100;
    public float experience = 100;

    private GameObject Tracker;

    void Awake()
    {
        Tracker = GameObject.FindGameObjectWithTag("Tracker");
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if(health <= 0)
        {
            Tracker.GetComponent<LevelSystem>().expGain(experience);
            Destroy(gameObject);
        }
    }
}
