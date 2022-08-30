using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TreeEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using Debug = UnityEngine.Debug;

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
    [SerializeField] [Range(5, 10)] private int damage;

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
        enemyAnimator.SetBool("hitPlayer", false);
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
        if (collision.gameObject.CompareTag("Player"))
        {
            enemyAnimator.SetBool("isRun", false);
            enemyAnimator.SetBool("hitPlayer", true);
            GameManager.PlayerHealth -= damage;
        }
        else if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(gameObject);
            GameManager.Score++;
        }
    }
}
