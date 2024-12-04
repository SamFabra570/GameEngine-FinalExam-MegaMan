using System.Collections.Generic;
using UnityEngine;

public class SnowflakePool : Singleton<SnowflakePool>
{
    private GameObject snowflake = null;
    
    Queue<GameObject> snowflakePool = new Queue<GameObject>();
    [SerializeField] int poolSize = 5;

    public SnowflakePool()
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
            Object.Instantiate(snowflake);
            snowflake.SetActive(false);

            snowflakePool.Enqueue(snowflake);
        }
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

    public void ReturnSnowflake(List<GameObject> snowflakes)
    {
        Queue<GameObject> currentPool = GetSnowflakePool();

        foreach (GameObject snowflake in snowflakes)
        {
            snowflake.SetActive(false);
            currentPool.Enqueue(snowflake);
        }
    }

    Queue<GameObject> GetSnowflakePool()
    {
        return snowflakePool;
    }
}