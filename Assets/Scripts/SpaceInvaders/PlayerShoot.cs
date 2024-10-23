using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public string fireButton = "left shift";
    public int fireRate = 3;
    private float nextShot = 0.0f;
    public GameObject bulletPrefab;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(fireButton) && Time.time > nextShot)
        {
            nextShot = Time.time + 1.0f / fireRate;
            Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        }
    }
}
