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

    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = scale;
    }

    // Update is called once per frame
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
        transform.position += direction * (Time.deltaTime * speed);
    }
}
