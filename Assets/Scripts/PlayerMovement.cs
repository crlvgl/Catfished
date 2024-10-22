using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D body;

    float horizontal;
    bool jump;
    bool open;
    bool close;

    public float speed = 5.0f;
    public float jumpForce = 5.0f;
    public GameObject window;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        // if (Input.GetKeyDown("space"))
        // {
        //     jump = true;
        // }
        if (Input.GetKeyDown("e"))
        {
            open = true;
        }
        if (Input.GetKeyDown("escape"))
        {
            close = true;
        }
    }

    void FixedUpdate()
    {
        // if (jump)
        // {
        //     body.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        //     jump = false;
        // }
        body.linearVelocity = new Vector2(horizontal * speed, body.linearVelocity.y);
        if (open)
        {
            window.SetActive(true);
            open = false;
        }
        if (close)
        {
            window.SetActive(false);
            close = false;
        }
    }
}
