using UnityEngine;

public class VSMovePlayer : MonoBehaviour
{
    Rigidbody2D body;

    public float speed = 5.0f;
    public float dampener = 0.7f;
    private float vertical;
    private float horizontal;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
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
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        if (horizontal == 0 || vertical == 0)
        {
            body.linearVelocity = new Vector2(horizontal * speed, vertical * speed);
        }
        else
        {
            body.linearVelocity = new Vector2(horizontal * speed, vertical * speed) * dampener;
        }
    }

    void OnPlayerDeath()
    {
        this.enabled = false;
    }
}
