using UnityEngine;

public class VSMoveEnemy : MonoBehaviour
{
    // relevant enemy components
    Rigidbody2D body;
    Renderer enemyRenderer;

    // Movement Variables
    [Header("Movement")]
    [Tooltip("The player GameObject for movement references; if not set, will find the player GameObject by name")]
    public GameObject player;
    [Tooltip("The speed of the enemy; should be slower than the player")]
    public float speed = 2f;
    private Vector3 direction;

    // Healt Variables
    [Header("Health")]
    [Tooltip("The health of the enemy; since no armor, more health for stronger enemies")]
    public int health = 10;
    [Tooltip("The damage the enemy deals to the player")]
    public int damage = 1;
    [Tooltip("XP item the enemy drops on death")]
    public GameObject xpItem;

    private bool playerDead = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        enemyRenderer = GetComponent<Renderer>();

        if (player == null)
        {
            player = GameObject.Find("Player");
        }
    }

    void OnEnable()
    {
        VSPlayerHealthXp.OnPlayerDeath += OnPlayerDeath;
    }

    void OnDisable()
    {
        VSPlayerHealthXp.OnPlayerDeath -= OnPlayerDeath;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerDead) // only move if player is dead
        {
            body.linearVelocity = direction * speed;
            Debug.Log(enemyRenderer.isVisible);
            if (!enemyRenderer.isVisible)
            {
                Destroy(this.gameObject);
            }
            return;
        }

        // Do everything if player is alive

        // Health
        if (health <= 0)
        {
            // Debug.Log("Enemy is dead");
            Instantiate(xpItem, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }

        // Movement
        direction = player.transform.position - transform.position;
        direction.Normalize();

        body.linearVelocity = direction * speed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            // Debug.Log("Player takes damage");
            player.GetComponent<VSPlayerHealthXp>().health -= damage;
        }
    }

    void OnPlayerDeath()
    {
        playerDead = true;
    }
}
