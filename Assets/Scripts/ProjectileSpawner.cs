using UnityEngine;
using System.Collections;

public class ProjectileSpawner : MonoBehaviour
{
    public GameObject projectile;
    public float fireRate;
    public bool spawnHorizontally;
    public float min;
    public float max;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(Spawner());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Spawner()
    {
        if (GameObject.Find("Player") == null)
        {
            yield break;
        }
        yield return new WaitForSeconds(1/fireRate);
        SpawnProjectile();
        StartCoroutine(Spawner());
    }

    private void SpawnProjectile()
    {
        if (spawnHorizontally)
        {
            Vector3 spawnPos = new Vector3(Random.Range(min, max), transform.position.y, transform.position.z);
            Instantiate(projectile, spawnPos, Quaternion.identity);
        }
        else
        {
            Vector3 spawnPos = new Vector3(transform.position.x, Random.Range(min, max), transform.position.z);
            Instantiate(projectile, spawnPos, Quaternion.identity);
        }
    }
}
