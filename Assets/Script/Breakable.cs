using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class Breakable : MonoBehaviour
{
    //private Animator anim;

    public GameObject[] brokenPiece;
    public int maxPieces = 5;
    public GameObject Healthitem;
    
    public float BoxHealth=100f;
    void Start()
    {
        //anim = GetComponent<Animator>();
    }

  
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            BoxHealth -= 10;
            
            if (BoxHealth <= 0)
            {
                //상자가 파괴 되면 조각들이 나온다.
                Destroy(gameObject);
                //박스가 부서졌을때 나오는 사운드
               AudioManager.instance.BoxBreakMusic.Play();

                int piecesToDrop = Random.Range(1, maxPieces);

                for (int i= 0; i < piecesToDrop; i++)
                {
                    int randomPieces = Random.Range(0, brokenPiece.Length);
                    Instantiate(brokenPiece[randomPieces], transform.position, transform.rotation);
                }

                float randomPickUp = Random.Range(0f, 100f);
                
                Instantiate(Healthitem, transform.position,transform.rotation);
            }
        }
        
        
    
    }
}
