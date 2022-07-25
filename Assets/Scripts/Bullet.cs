using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 5f;
    public Vector3 direction = new Vector3(0, 0.5f, 1f);
    private Vector3 scale = new Vector3(0.5f, 0.5f, 0.5f);
    private Vector3 position = new Vector3(0.02f, 1.09f, 1.6f);
    
    void Start()
    {
        transform.localScale = scale;
        transform.position = position;
    }

    void Update()
    {
        Move();
    }
    
    private void Move()
    {
        transform.position += direction * (Time.deltaTime * speed);
    }
}
