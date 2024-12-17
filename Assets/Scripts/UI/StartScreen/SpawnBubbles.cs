using UnityEngine;
using System.Collections;

public class SpawnBubbles : MonoBehaviour
{
    public GameObject bubblePrefab;
    public float spawnRateMin = 0.5f;
    public float spawnRateMax = 1.0f;
    public float spawnXMin = 0.0f;
    public float spawnXMax = 10.0f;
    private float spawnX = 0.0f;
    public float minSpawnDistance = 1.0f;

    void Start()
    {
        StartCoroutine(SpawnBubblesCoroutine());
    }

    void Update()
    {

    }

    IEnumerator SpawnBubblesCoroutine()
    {
        float spawnXTemp = spawnX;
        while (Mathf.Abs(spawnXTemp - spawnX) < minSpawnDistance)
        {
            spawnXTemp = Random.Range(spawnXMin, spawnXMax);
        }
        spawnX = spawnXTemp;
        Instantiate (bubblePrefab, new Vector3(spawnX, this.transform.position.y, 0.0f), Quaternion.Euler(0.0f, 0.0f, Random.Range(0.0f, 360.0f)));
        yield return new WaitForSeconds(Random.Range(spawnRateMin, spawnRateMax));
        StartCoroutine(SpawnBubblesCoroutine());
    }
}