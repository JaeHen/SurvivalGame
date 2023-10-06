using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    //싱글톤으로하여 어디서든 갖다쓰게함
    public static PlayerBullet instance;
    public float speed = 7f;
    public Rigidbody2D rigid;
    private int Bullet_Damage = 10;


    void Start()
    {
      
        rigid = GetComponent<Rigidbody2D>();
        instance = this;
    }

  
    void Update()
    {
        //총알 발사 코드 구현 
        rigid.velocity = transform.right * speed;
        Destroy(gameObject,2f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Box"))
        {
            //총알이 박스에 부딪히면 없어지게함
            Destroy(gameObject);
        }
        
        if (other.CompareTag("Enemy"))
        {
            
            other.GetComponent<EnemyController>().OnDamage(Bullet_Damage);
            Destroy(gameObject);
            AudioManager.instance.EnemyHurtMusic.Play();
          
          
        }
       
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
