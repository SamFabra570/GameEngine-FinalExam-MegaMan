using System.Collections.Generic;
using UnityEngine;

public class FireCommand : Command
{
    Rigidbody2D rb;
    int bulletSpeed;
    Vector2 direction;
    static List<GameObject> activeBullets = new List<GameObject>();
    public FireCommand(Rigidbody2D rb, int bulletSpeed, Vector2 direction)
    {
        this.rb = rb;
        this.bulletSpeed = bulletSpeed;
        this.direction = direction;
    }

    public override void Execute()
    {
        /*GameObject bulletInstance = BulletPool.Instance.GetBullet(bulletType);
        bulletInstance.transform.position = rb.transform.position;

        Rigidbody2D bulletRb = bulletInstance.GetComponent<Rigidbody2D>();

        if (direction == Vector2.zero)
        {
            bulletRb.linearVelocityX = bulletSpeed;
        }
        else
            bulletRb.linearVelocity = direction * bulletSpeed;

        activeBullets.Add(bulletInstance);

        if (activeBullets.Count == 5) 
        {
            BulletPool.Instance.ReturnBullets(activeBullets, bulletType);
            activeBullets.Clear();
        */}

    }