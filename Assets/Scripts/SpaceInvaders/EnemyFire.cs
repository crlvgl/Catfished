using UnityEngine;

public class EnemyFire : MonoBehaviour
{
    public GameObject bulletPrefab;
    public int enemyNumber = 0;
    private float nextShot = 0.0f;
    public int fireRate = 3;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (EnemyFireControl.enemyFires == enemyNumber && Time.time > nextShot && PlayerHealth.health > 0)
        {
            nextShot = Time.time + 1.0f / fireRate;
            Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        }
    }
}
