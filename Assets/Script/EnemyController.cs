using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyController : MonoBehaviour
{
    public static EnemyController instance;
    
   
     Transform target;
   
     [Header("이동 스피드")]
    public float moveSpeed=5f;

    private Rigidbody2D rigid;
    private SpriteRenderer spriter;
    private Animator anim;

    // 체력 
    [Header("체력과 데미지")]
    public int Health = 30;

    //몬스터 공격 데미지
    public int EnemyDamage = 1;


    private void OnEnable()
    {
      
        //findgameobjectwithtag로 위치를 찾아낸다. 
       target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Start()
    {
        //초기화
        rigid = GetComponent<Rigidbody2D>();
        spriter = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        instance = this;
    }

  
    void FixedUpdate()
    {
        // c 속도로 a 에서 b 까지 추격을 하게 만들었습니다. 
        transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
        //움직이는 애니메이션을 추가했습니다.
        anim.SetBool("isMoving",true);
        


    }

   public void OnDamage(int damage)
    {
        Health -= damage;
        
        if (Health <= 0)
        {
          
            // 체력이 0 이하가 되었을때 몬스터는 작동이 중지된다. 
            gameObject.SetActive(false);
            //몬스터가 죽는 음악
            AudioManager.instance.EnemyDeathMusic.Play();
          
            //사망했을때 킬수와 경험치 얻기
            GameManagers.instance.kill++;
            GameManagers.instance.GetExp();
        }
    }

   
  
}
