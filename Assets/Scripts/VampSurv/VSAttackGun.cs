using UnityEngine;
using System.Collections;

public class VSAttackGun : MonoBehaviour
{
    public GameObject bullet;
    public float fireRate = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnEnable()
    {
        StartCoroutine(FireBullets());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator FireBullets()
    {
        Quaternion[] bulletRotations = {
            Quaternion.Euler(0, 0, 135), // (-1,  1, 0)
            Quaternion.Euler(0, 0, 45),  // ( 1,  1, 0)
            Quaternion.Euler(0, 0, -45), // ( 1, -1, 0)
            Quaternion.Euler(0, 0, -135) // (-1, -1, 0)
        };

        foreach (Quaternion rotation in bulletRotations)
        {
            Instantiate(bullet, transform.position, rotation);
        }
        
        yield return new WaitForSeconds(fireRate);
        StartCoroutine(FireBullets());
    }
}