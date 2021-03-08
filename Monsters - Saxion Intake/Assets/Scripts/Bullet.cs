using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed = 15f;
    public Rigidbody2D rb;
    private float lifeTime = 1f;

    private void FixedUpdate()
    {
        rb.velocity = transform.right * bulletSpeed;
        Destroy(gameObject, lifeTime);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(gameObject);
    }
}
