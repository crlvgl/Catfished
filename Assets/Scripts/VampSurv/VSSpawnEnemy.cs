using UnityEngine;
using System.Collections;

public class VSSpawnEnemy : MonoBehaviour
{
    public GameObject enemy;
    public float timeBetweenSpawns = 5.0f;
    public float spawnGroupSize = 5;
    public float groupProbability = 0.5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnEnemy()
    {
        yield return new WaitForSeconds(timeBetweenSpawns);
        float random = Random.Range(0.0f, 1.0f);
        if (random < groupProbability)
        {
            for (int i = 0; i < spawnGroupSize; i++)
            {
                Instantiate(enemy, transform.position, Quaternion.identity);
            }
        }
        else
        {
            Instantiate(enemy, transform.position, Quaternion.identity);
        }
        StartCoroutine(SpawnEnemy());
    }
}
