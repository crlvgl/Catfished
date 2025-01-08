using UnityEngine;

public class EnemyFire : MonoBehaviour
{
    public GameObject bulletPrefab;
    private float nextShot = 0.0f;
    public int fireRate = 3;
    private bool rollRandom = false;
    private float fireFor = 0f;
    private bool waitFor = true;
    private float waitForTime = 0f;
    private PlayerHealth playerHealthSI;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerHealthSI = GameObject.Find("Player").gameObject.GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerHealthSI.health <= 0 || this.transform.position.y > 14.5 || this.transform.position.y < -12)
        {
            return;
        }
        if (rollRandom)
        {
            rollRandom = false;
            fireFor = Time.time + Random.Range(1, 10);
        }
        else if (!rollRandom && Time.time > fireFor)
        {
            if (waitFor)
            {
                waitFor = false;
                waitForTime = Time.time + Random.Range(1, 30);
            }
            else if (!waitFor && Time.time > waitForTime)
            {
                rollRandom = true;
                waitFor = true;
            }
        }
        if (Time.time > nextShot && Time.time < fireFor)
        {
            nextShot = Time.time + 1.0f / fireRate;
            Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        }
    }
}
