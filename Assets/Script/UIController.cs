using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIController : MonoBehaviour
{
    public static UIController Instance;
    //체력바 , 그리고 체력바 안에있는 텍스트 구현
    public Slider healthSilder;
    public Text healthText;
    public GameObject deadScreen;

    
    
    public enum InfoType{Exp,Level,Kill,Time}

    public InfoType Type;
    
    void Awake()
    {
        //초기화
      
        Instance = this;
    }

  
}
