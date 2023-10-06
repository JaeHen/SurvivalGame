using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthItem : MonoBehaviour
{
    public int HealAmount = 1;
    
    void Start()
    {
        
    }

  
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            AudioManager.instance.PickUpHealthItemMusic.Play();
            PlayerController.instance.HealPlayer(HealAmount);
            Destroy(gameObject);
        }
    }
}
