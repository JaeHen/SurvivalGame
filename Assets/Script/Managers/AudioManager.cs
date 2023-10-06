using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public AudioSource audioMusic,WinMusic,GameoverMusic,ShootMusic,BoxBreakMusic,EnemyDeathMusic
        ,PlayerHurtMusic,PickUpHealthItemMusic,EnemyHurtMusic;
    void Start()
    {
        instance = this;
    }

  
    void Update()
    {
        
    }

    public void PlayGameOver()
    {
        audioMusic.Stop();
        GameoverMusic.Play();
    }

    public void PlayLevelWin()
    {
        audioMusic.Stop();
        WinMusic.Play();
    }
}
