using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ExpController : MonoBehaviour
{

    public enum InfoType{Exp,Level,Kill,Time}

    public InfoType Type;

      Text myText;
     Slider mySlider;
    void Awake()
    {
        //초기화
        myText = GetComponent<Text>();
        mySlider = GetComponent<Slider>();
    }

  
    void LateUpdate()
    {
        switch (Type)
        {
            case InfoType.Exp:
                float curExp = GameManagers.instance.exp;
                float maxExp = GameManagers.instance.nextExp[GameManagers.instance.level];
                mySlider.value = curExp/maxExp;
                break;
            
            case InfoType.Level:
                myText.text = string.Format("Lv.{0:F0}", GameManagers.instance.level);
                break;
            
            case InfoType.Kill:
                myText.text = string.Format("{0:F0}", GameManagers.instance.kill);
                break;
            
            case InfoType.Time:
                break;
        }
    }
}
