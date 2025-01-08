using UnityEngine;

public class MovementFB : MonoBehaviour
{
    Rigidbody2D body;
    public float jumpForce = 10f;
    private bool jump = false;
    private ScoreFB scoreFB;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        body = GetComponent<Rigidbody2D>();

        scoreFB = GameObject.Find("Score").gameObject.GetComponent<ScoreFB>();
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
            body.AddForce(Vector2.up * jumpForce * (scoreFB.speed / 5f), ForceMode2D.Impulse);
            jump = false;
        }
    }
}
