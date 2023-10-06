using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //싱글톤
    public static PlayerController instance;
    
   public float moveSpeed=10f;
   private Vector2 moveInput;
   public Rigidbody2D rigid;
   private Camera mainCamera;
   
   public GameObject gun;
   public Transform gunArm;

   public Animator anim;
   
   
   //총알
   public GameObject bullet;
   public Transform firePoint;

   public int PlayerHealth;
   public int PlayerMaxHealth=5;
   
   public SpriteRenderer spriteRenderer;
    void Start()
    {
        //플레이거 체력은 현재 맥스다.
        PlayerHealth = PlayerMaxHealth;
        
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        instance = this;
        mainCamera = Camera.main;

        //체력바를 표현하는코드 
        UIController.Instance.healthSilder.maxValue = PlayerMaxHealth;
        UIController.Instance.healthSilder.value = PlayerHealth;
        UIController.Instance.healthText.text = PlayerHealth.ToString()+"/"+PlayerMaxHealth.ToString();
    }

  
    void Update()
    {
        //벡터를 이용한 마우스 총 조준 
        MouseCheck();
        
        //이동 관련 코드 
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");
        rigid.velocity = moveInput * moveSpeed;
        
        // 마우스 위치와 스크린에 포인트를 알아내어 마우스 위치에 따라 캐릭터 방향 전환 코드
        Vector3 mousePos = Input.mousePosition;
        Vector2 screenPoint= mainCamera.WorldToScreenPoint(transform.localPosition);

        //마우스 x 위치가 작으니면 윈쪽으로 방향전화 아니면 오륵쪽으로 전환
        if (mousePos.x < screenPoint.x)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
            gunArm.localScale = new Vector3(-1f, -1f, 1f);
        }
        else
        {
            transform.localScale = Vector3.one;
            gunArm.localScale = Vector3.one;
        }
        //총알 발사 구현
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(bullet,firePoint.position,firePoint.rotation);
            AudioManager.instance.ShootMusic.Play();
        }
        

    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            //데미지는 주는 코드
            DamagePlayer();
            
            AudioManager.instance.PlayerHurtMusic.Play();
         
            //적 몬스터와 닿으면 뒤로 팅겨나감 , 색깔도 살짝 바낌 ,  레이어도 바뀜
            //레이어를 바꿈으로써 무적상태를 만듬
            gameObject.layer = 12;
            
            spriteRenderer.color = new Color(1, 1, 1, 0.4f);
            
            //3초간 무적
          Invoke("OffDamage",3f);
        }
       
    }

    public void DamagePlayer()
    {
        PlayerHealth -= EnemyController.instance.EnemyDamage;
      
       
        
        if (PlayerHealth <= 0)
        {
            gameObject.SetActive(false);
            EnemyController.instance.gameObject.SetActive(false);
                
            //축으면 화면이 뜨는 코드
            UIController.Instance.deadScreen.SetActive(true);

            //체력이 0이 되었을때 노래
            AudioManager.instance.PlayGameOver();
        }
            
        //체력바를 서서히 깍아내리는코드
        UIController.Instance.healthSilder.value = PlayerHealth;
        UIController.Instance.healthText.text = PlayerHealth.ToString()+"/"+PlayerMaxHealth.ToString();
    }

    void OffDamage()
    {
        gameObject.layer = 8;
        spriteRenderer.color = new Color(1, 1, 1, 1);
    }
    void MouseCheck()
    {
        
        //벡터로 마우스 방향
        Vector3 mousePos = Input.mousePosition;
        mousePos = mainCamera.ScreenToWorldPoint(mousePos);

        Vector3 playerPos = transform.position;

        //벡터로 크기와 방향을 알수잇다
        Vector2 dirVec = mousePos - playerPos;
        
        gun.transform.right = dirVec.normalized;

    }


    public void HealPlayer(int healAmount)
    {
        PlayerHealth += healAmount;
        if (PlayerHealth > PlayerMaxHealth)
        {
            PlayerHealth = PlayerMaxHealth;
        }
        
        //체력아이템을 먹으면 UI도 같이 변하게 한다.
        UIController.Instance.healthSilder.value = PlayerHealth;
        UIController.Instance.healthText.text = PlayerHealth.ToString()+"/"+PlayerMaxHealth.ToString();
    }
}
