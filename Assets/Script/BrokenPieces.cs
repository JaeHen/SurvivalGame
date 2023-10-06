using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenPieces : MonoBehaviour
{
    public float moveSpeed = 3f;
    private Vector3 moveDirection;

    public float deceleration = 5f;
    
    
    void Start()
    {
        moveDirection.x = Random.Range(-moveSpeed, moveSpeed);
        moveDirection.y = Random.Range(-moveSpeed, moveSpeed);
    }

  
    void Update()
    {
        transform.position += moveDirection * Time.deltaTime;

        //박스가 터졌을때 조각들이 적당히 퍼지도록 하는코드
        moveDirection = Vector3.Lerp(moveDirection,Vector3.zero,deceleration*Time.deltaTime);
        
        //조각이 퍼지고 4초뒤 사라짐
        Destroy(gameObject,4f);
    }
}
