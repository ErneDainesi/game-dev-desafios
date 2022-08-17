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
    [SerializeField] private float lookSpeed = 1f;
    [SerializeField] private float speed = 1f;
    [SerializeField] private Animator enemyAnimator;
    
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
                Invoke("CrawlerMove", 2f);
                break;
            case ZombieType.Stalker:
                Stalk();
                break;
        }
    }

    private void CrawlerMove()
    { 
        Stalk();
        Crawl();
        enemyAnimator.SetBool("isRun", true);
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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            enemyAnimator.SetBool("isRun", false);
        }
    }
}
