using System;
using UnityEngine;

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
            Time.deltaTime * 5f);
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