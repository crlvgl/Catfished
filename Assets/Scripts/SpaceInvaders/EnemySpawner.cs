using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    public float spawnTime = 2f;
    public GameObject enemyPrefab;

    private PlayerHealth playerHealthSI;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerHealthSI = GameObject.Find("Player").gameObject.GetComponent<PlayerHealth>();

        StartCoroutine(SpawnEnemy());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnEnemy()
    {
        if (playerHealthSI.health > 0)
        {
            yield return new WaitForSeconds(spawnTime);
            Instantiate(enemyPrefab, transform.position, this.transform.rotation);
            StartCoroutine(SpawnEnemy());
        }
    }
}
