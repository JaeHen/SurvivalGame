using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class EnemySpawner : MonoBehaviour
{
    public Transform[] spawnPoint;

    private float timer;

    private void Awake()
    {
        spawnPoint=GetComponentsInChildren<Transform>();
    }

    void Update()
    {
        timer += Time.deltaTime;
        
         if (timer>0.2f)
         {
             spawn();
             timer = 0;
         }
         
     }

    void spawn()
    {
       GameObject enemy= GameManagers.instance.pool.Get(Random.Range(0,2));
       enemy.transform.position = spawnPoint[Random.Range(1,spawnPoint.Length)].position;
    }
}
