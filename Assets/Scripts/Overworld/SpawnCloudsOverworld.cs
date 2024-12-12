using UnityEngine;

public class SpawnCloudsOverworld : MonoBehaviour
{
    public GameObject cloudPrefab;
    public float cloudSpeed = 1.0f;
    public float cloudSize = 48.0f;
    private float timeBetweenSpawns;

    void Start()
    {
        timeBetweenSpawns = cloudSize / cloudSpeed;
        InvokeRepeating("SpawnCloud", timeBetweenSpawns, timeBetweenSpawns);
    }

    void SpawnCloud()
    {
        Instantiate(cloudPrefab, this.transform.position, Quaternion.identity);
    }
}