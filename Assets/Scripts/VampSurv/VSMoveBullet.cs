using UnityEngine;

public class VSMoveBullet : MonoBehaviour
{
    public float bulletSpeed = 5.0f;
    public int bulletDamage = 3;
    public float distanceToDestroy = 15.0f;

    private GameObject player;

    void Start()
    {
        player = GameObject.Find("Player");

        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), player.GetComponent<Collider2D>());
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) > distanceToDestroy)
        {
            Destroy(this.gameObject);
        }
    }

    void FixedUpdate()
    {
        transform.position += transform.up * bulletSpeed * Time.deltaTime;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name != "Player")
        {
            collision.gameObject.GetComponent<VSMoveEnemy>().health -= bulletDamage;
            Destroy(this.gameObject);
        }
    }
}