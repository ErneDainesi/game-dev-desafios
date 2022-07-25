using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorController : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public float spawnDelay = 2f;
    public float repeatRate = 2f;
    
    void Start()
    {
        // Invoke(nameof(SpawnEnemy), spawnDelay);
        InvokeRepeating(nameof(SpawnEnemy), spawnDelay, repeatRate);
    }

    void Update()
    {
        
    }
    
    private void SpawnEnemy()
    {
        int enemyPrefab = Random.Range(0, enemyPrefabs.Length);
        Instantiate(enemyPrefabs[enemyPrefab], transform);
    }
}
