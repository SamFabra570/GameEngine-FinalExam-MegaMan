using System.Collections.Generic;
using UnityEngine;

public class SnowflakePool : Singleton<SnowflakePool>
{
    private GameObject snowflake = null;
    
    Queue<GameObject> snowflakePool = new Queue<GameObject>();
    [SerializeField] int poolSize = 5;


    public override void Awake()
    {
        snowflake = LoadPrefab("Prefabs/Snowflake");
    }

    private GameObject LoadPrefab(string path)
    {
        GameObject prefab = Resources.Load<GameObject>(path);
        
        if (prefab == null)
        {
            Debug.LogError("Prefab not found at path: " + path);
        }

        return prefab;
    }
    
    void Start()
    {
        for (int i = 0; i < poolSize; i++)
        {
            CreateSnowflake();
            snowflake.SetActive(false);

            snowflakePool.Enqueue(snowflake);
        }
    }
    
    public GameObject CreateSnowflake()
    {
        return snowflake != null ? Object.Instantiate(snowflake) : null;
        //Debug.LogError("Snowflake prefab not found");
        //return null;
    }

    public GameObject GetSnowflake()
    {
        Queue<GameObject> currentPool = GetSnowflakePool();
        if (currentPool.Count > 0)
        {
            GameObject snowflake = currentPool.Dequeue();
            snowflake.SetActive(true);
            return snowflake;
        }
        else
        {
            Debug.Log("No more snow!");
            return null;
        }
    }

    public void ReturnSnowflake()
    {
        Queue<GameObject> currentPool = GetSnowflakePool();

        snowflake.SetActive(false);
        currentPool.Enqueue(snowflake);
    }

    Queue<GameObject> GetSnowflakePool()
    {
        return snowflakePool;
    }
}