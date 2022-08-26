using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAmmo : MonoBehaviour
{
    private float speed = 1000f;
    private Vector3 direction = Vector3.forward;
    private float lifeTime = 10f;
    void Start()
    {
        speed = 3f;
        Invoke("DestroyBullet", lifeTime);
    }

    void Update()
    {
        Move();
    }
    
    private void Move()
    {
        transform.position += direction * (Time.deltaTime * speed);
    }
    
    private void DestroyBullet()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            GameManager.Score++;
            DestroyBullet();
        }
    }
}
