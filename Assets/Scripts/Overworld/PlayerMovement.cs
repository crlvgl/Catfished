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

    public Animator anim;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (phone == null)
        {
            phone = Camera.main.transform.Find("Smartphone").gameObject;
        }
        if (anim == null)
        {
            anim = this.transform.Find("MC-Idle-FINAL").GetComponent<Animator>();
        }

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
                    anim.SetBool("Climb", true);
                    anim.SetBool("Fish", false);
                    anim.SetBool("Idle", false);
                    anim.SetBool("Walk", false);
                    anim.SetBool("Win", false);
                }
                else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
                {
                    anim.SetBool("Climb", false);
                    anim.SetBool("Fish", false);
                    anim.SetBool("Idle", false);
                    anim.SetBool("Walk", true);
                    anim.SetBool("Win", false);
                }
                else
                {
                    anim.SetBool("Climb", false);
                    anim.SetBool("Fish", false);
                    anim.SetBool("Idle", true);
                    anim.SetBool("Walk", false);
                    anim.SetBool("Win", false);
                }
            }
            else
            {
                if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
                {
                    anim.SetBool("Climb", false);
                    anim.SetBool("Fish", false);
                    anim.SetBool("Idle", false);
                    anim.SetBool("Walk", true);
                    anim.SetBool("Win", false);
                }
                else
                {
                    anim.SetBool("Climb", false);
                    anim.SetBool("Fish", false);
                    anim.SetBool("Idle", true);
                    anim.SetBool("Walk", false);
                    anim.SetBool("Win", false);
                }
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                this.transform.rotation = Quaternion.Euler(0, 180, 0);
            }
            else if (Input.GetKeyDown(KeyCode.D))
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
