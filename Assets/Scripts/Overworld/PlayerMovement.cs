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
    public GameObject pauseMenu;
    public KeyCode pauseKey = KeyCode.Escape;
    public GameObject phone;

    private bool ladderExists;
    private Ladder ladder;

    private Animator anim;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.enabled = false;

        body = GetComponent<Rigidbody2D>();
        ladderExists = GameObject.Find("Ladder") != null;

        if (ladderExists)
        {
            ladder = GameObject.Find("Ladder").gameObject.GetComponent<Ladder>();
        }

        if (pauseMenu == null)
        {
            pauseMenu = GameObject.Find("PauseScreen");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!pauseMenu.activeSelf)
        {
            horizontal = Input.GetAxisRaw("Horizontal");
            vertical = Input.GetAxisRaw("Vertical");
            if (ladderExists)
            {
                if (ladder.isOnLadder && (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S)))
                {
                    anim.enabled = true;
                    anim.SetBool("Walk", false);
                    anim.SetBool("Fish", false);
                    anim.SetBool("Climb", true);
                }
                else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
                {
                    anim.enabled = true;
                    anim.SetBool("Walk", true);
                    anim.SetBool("Fish", false);
                    anim.SetBool("Climb", false);
                }
                else
                {
                    anim.enabled = false;
                }
            }
            else
            {
                if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
                {
                    anim.enabled = true;
                    anim.SetBool("Walk", true);
                    anim.SetBool("Fish", false);
                }
                else
                {
                    anim.enabled = false;
                }
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                this.transform.rotation = Quaternion.Euler(0, 180, 0);
            }
            else if (Input.GetKeyUp(KeyCode.A))
            {
                this.transform.rotation = Quaternion.Euler(0, 0, 0);
            }
        }
        if (Input.GetKeyDown(pauseKey))
        {
            open = true;
        }
    }

    void FixedUpdate()
    {
        if (!pauseMenu.activeSelf)
        {
            // if (!phone.activeSelf)
            // {
            //     phone.SetActive(true);
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
                body.linearVelocity = new Vector2(horizontal * speed, body.linearVelocity.y);
            }
        }
        // else if (pauseMenu.activeSelf)
        // {
        //     if (phone.activeSelf)
        //     {
        //         phone.SetActive(false);
        //     }
        // }
        if (open)
        {
            pauseMenu.SetActive(!pauseMenu.activeSelf);
            open = false;
        }
    }
}
