using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int damage;
    public int health;
    public float speed;
    public Vector3 scale = new Vector3(1f, 1f, 1f);
    public Vector3 direction;
    public int healthPotion;
    public string playerName = "Hero";

    void Start()
    {
        transform.localScale = scale;
    }

    void Update()
    {
        Move();
        TakeDamage();
        UseHealthPotion();
    }

    private void TakeDamage()
    {
        health -= damage;
    }

    private void UseHealthPotion()
    {
        health += healthPotion;
    }

    private void Move()
    {
        if (Input.GetKey(KeyCode.W))
        {
            MovePlayer(Vector3.forward);
        }

        if (Input.GetKey(KeyCode.S))
        {
            MovePlayer(Vector3.back);
        }

        if (Input.GetKey(KeyCode.A))
        {
            MovePlayer(Vector3.left);
        }

        if (Input.GetKey(KeyCode.D))
        {
            MovePlayer(Vector3.right);
        }
    }
    
    private void MovePlayer(Vector3 direction)
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }
}
