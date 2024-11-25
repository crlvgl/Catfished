using UnityEngine;

public class VSMoveEnemy : MonoBehaviour
{
    Rigidbody2D body;

    public GameObject player;
    public float speed = 2f;
    private Vector3 direction;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        body = GetComponent<Rigidbody2D>();

        if (player == null)
        {
            player = GameObject.Find("Player");
        }
    }

    // Update is called once per frame
    void Update()
    {
        direction = player.transform.position - transform.position;
        direction.Normalize();

        body.linearVelocity = direction * speed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Debug.Log("Player has died");
            Destroy(this.gameObject);
        }
    }
}
