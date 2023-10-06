using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagers : MonoBehaviour
{
    public static GameManagers instance;
    public PoolManager pool;

    [Header("# Player Info")]
   public int level;
   public int kill;
   public int exp;
   public int[] nextExp ;
    void Start()
    {
        instance = this;
    }

  
    void Update()
    {
        
    }

    public void GetExp()
    {
        exp++;
        if (exp == nextExp[level])
        {
            level++;
            exp = 0;
            
        }
    }
}
