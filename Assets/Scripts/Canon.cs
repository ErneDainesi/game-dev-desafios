using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canon : MonoBehaviour
{
    public GameObject bullet;
    public float invokeDelay = 1f;
    public float invokeRepeat = 2f;
    
    void Start()
    {
        InvokeRepeating("Shoot", invokeDelay, invokeRepeat);
    }
    
    void Update()
    {
        
    }

    private void Shoot()
    {
        Instantiate(bullet);
    }
}
