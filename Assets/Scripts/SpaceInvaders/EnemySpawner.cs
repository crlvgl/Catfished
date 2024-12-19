using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    public float spawnTime = 2f;
    public GameObject enemyPrefab;
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
        if (GameObject.Find("Player").gameObject.GetComponent<PlayerHealth>().health > 0)
        {
            yield return new WaitForSeconds(spawnTime);
            Instantiate(enemyPrefab, transform.position, this.transform.rotation);
            StartCoroutine(SpawnEnemy());
        }
    }
}
