using System;
using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public GameObject[] m_prefab;

    private List<GameObject>[] pools;

    private void Awake()
    {
        pools = new List<GameObject>[m_prefab.Length];

        for (int index = 0; index < pools.Length; index++)
        {
            pools[index] = new List<GameObject>();
        }
    }

    public GameObject Get(int index)
    {
        GameObject select = null;

        foreach (GameObject item in  pools[index])
        {
            if (!item.activeSelf)
            {
                select = item;
                select.SetActive(true);
                break;
            }
        }

        if (!select)
        {
            select = Instantiate(m_prefab[index], transform.position,Quaternion.identity);
            pools[index].Add(select);
        }
        return select;
        
    }
    void Update()
    {
        
    }
}
