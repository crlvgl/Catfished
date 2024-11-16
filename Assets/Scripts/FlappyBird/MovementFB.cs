using UnityEngine;

public class MovementFB : MonoBehaviour
{
    Rigidbody2D body;
    public float jumpForce = 10f;
    private bool jump = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            jump = true;
        }
    }

    void FixedUpdate()
    {
        if (jump)
        {
            body.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            jump = false;
        }
    }
}
