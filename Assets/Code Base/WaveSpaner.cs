using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpaner : MonoBehaviour
{
    [SerializeField] private GameObject Enemy;
    [SerializeField] private float wavePeriod = 3f;
    [SerializeField] private float enemySpawnRate = 5f;

    private uint waveCounter = 1;
    // Start is called before the first frame update
    void Start()
    {
        if(Enemy == null) Debug.LogError("Enemy is empty");
        StartCoroutine(SpawnWave());
    }

    IEnumerator SpawnWave()
    {
        if(waveCounter == 1) yield return new WaitForSeconds(3);
        else yield return new WaitForSeconds(wavePeriod);
        for (int i = 0; i < 10 + waveCounter * 2; i++)
        {
            Instantiate(Enemy, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(10 / enemySpawnRate);
        }

        waveCounter++;
        StartCoroutine(SpawnWave());
        
    }
}
