using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    [SerializeField] private GameObject zombie;
    [SerializeField]private float waitingTime = 2f;
    [SerializeField]private float repetitionTime = 2f;
    
    void Start()
    {
      InvokeRepeating("SpawnZombie", waitingTime, repetitionTime);  
    }
    
    private void SpawnZombie()
    {
        Instantiate(zombie, transform);
    }
}
