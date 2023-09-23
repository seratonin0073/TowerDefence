using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject Enemy;
    [SerializeField] private float spawnRate = 2f;
    [SerializeField ]private float startSpawnDelay = 2f;
    void Start()
    {
        if(Enemy == null) Debug.LogError("Enemy is empty");
        InvokeRepeating("Spawn", startSpawnDelay, 10/spawnRate);
    }

    private void Spawn()
    {
        Instantiate(Enemy, transform.position, Quaternion.identity);
    }

    void Update()
    {
        
    }
}
