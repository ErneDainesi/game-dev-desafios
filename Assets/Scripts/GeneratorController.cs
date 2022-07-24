using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorController : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnDelay = 2f;
    public float repeatRate = 2f;
    
    // Start is called before the first frame update
    void Start()
    {
        Invoke(nameof(SpawnEnemy), spawnDelay);
        InvokeRepeating(nameof(SpawnEnemy), spawnDelay, repeatRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void SpawnEnemy()
    {
        Instantiate(enemyPrefab, transform);
    }
}
