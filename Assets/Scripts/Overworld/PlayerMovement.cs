using UnityEngine;
public class PlayerMovement : MonoBehaviour

{
    Rigidbody2D body;

    float horizontal;
    float vertical;
    bool jump;
    bool open;
    bool close;

    public float speed = 5.0f;
    public float jumpForce = 5.0f;
    public GameObject window;
    public KeyCode pauseKey = KeyCode.Escape;

    private bool ladderExists;
    private Ladder ladder;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        ladderExists = GameObject.Find("Ladder") != null;

        if (ladderExists)
        {
            ladder = GameObject.Find("Ladder").gameObject.GetComponent<Ladder>();
        }

        if (window == null)
        {
            window = GameObject.Find("PauseMenu");
        }
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        // if (Input.GetKeyDown("space"))
        // {
        //     jump = true;
        // }
        if (Input.GetKeyDown(pauseKey))
        {
            open = true;
        }
    }

    void FixedUpdate()
    {
        // if (jump)
        // {
        //     body.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        //     jump = false;
        // }
        if (ladderExists)
        {
            if (ladder.isOnLadder == false)
            {
                body.linearVelocity = new Vector2(horizontal * speed, body.linearVelocity.y);
            }
            else
            {
                body.linearVelocity = new Vector2(horizontal * speed, vertical * speed);
            }
        }
        else
        {
            body.linearVelocity = new Vector2(horizontal * speed, vertical * speed);
        }
        if (open)
        {
            window.SetActive(!window.activeSelf);
            open = false;
        }
    }
}
