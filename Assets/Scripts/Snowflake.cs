using System;
using UnityEngine;
using UnityEngine.UIElements;

public class Snowflake : MonoBehaviour
{
    public GameObject target;

    private void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position,
            Time.deltaTime * 2.5f);

        if (transform.position.y < target.transform.position.y)
        {
            Debug.Log("fuck outta here");
            SnowflakePool.Instance.ReturnSnowflake();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("ouch");
        
        /*if (collision.gameObject.CompareTag("Target"))
        {
            Debug.Log("bawk bawk in da barn");

            GameManager gameManager = FindObjectOfType<GameManager>();



            if (gameManager != null)
            {
                gameManager.AddChicken(chickensAdded);
            }
            else
            {
                Debug.LogError("GameManager not found");
            }

            Destroy(gameObject);
        }*/
    }
}