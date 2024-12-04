using System;
using System.Collections.Generic;
using UnityEngine;

public class SnowflakeSpawner : MonoBehaviour
{
    static List<GameObject> activeSnowflakes = new List<GameObject>();
    private Vector2 direction;
    private Rigidbody2D rb;

    public int snowflakeSpeed;

    private GameObject snowflakeInstance;
    public Rigidbody2D snowflakeRb;

    private void Awake()
    {
        snowflakeInstance = SnowflakePool.Instance.GetSnowflake();
        //snowflakeRb = snowflakeInstance.GetComponent<Rigidbody2D>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        snowflakeInstance.transform.position = rb.transform.position;

        /*if (direction == Vector2.zero)
        {
            snowflakeRb.linearVelocityX = snowflakeSpeed;
        }
        else
            snowflakeRb.linearVelocity = direction * snowflakeSpeed;*/

        activeSnowflakes.Add(snowflakeInstance);

        if (activeSnowflakes.Count == 4) 
        {
            SnowflakePool.Instance.ReturnSnowflake();
            activeSnowflakes.Clear();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
