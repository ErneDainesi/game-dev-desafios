using System;
using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public class Zombie : MonoBehaviour
{
    enum ZombieType
    {
        Crawler,
        Stalker
    }

    [SerializeField] private ZombieType zombie;
    [SerializeField] private Transform playerTransform;
    public float lookSpeed = 1f;
    public float speed = 1f;
    
    void Start()
    {
        
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        switch (zombie)
        {
            case ZombieType.Crawler:
                Stalk();
                Crawl();
                break;
            case ZombieType.Stalker:
                Stalk();
                break;
        }
    }

    private void Crawl()
    {
        Vector3 direction = (playerTransform.position - transform.position);
        if (direction.magnitude > 2f) {
            transform.position += speed * Time.deltaTime * direction.normalized;
        }
    }
    
    private void Stalk()
    {
        Quaternion newRotation = Quaternion.LookRotation(playerTransform.position - transform.position);
        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, lookSpeed * Time.deltaTime);
    }
}
