using UnityEngine;
public class PlayerMovement : MonoBehaviour

{
    private Animator anim;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;

    float horizontal;
    float vertical;
    bool jump;
    bool open;
    bool close;

    [Header("Movement Settings")]
    public float walkSpeed = 5f;
    public float jumpForce = 5f;


    public GameObject pauseMenu;
    public KeyCode pauseKey = KeyCode.Escape;

    private bool ladderExists;
    private Ladder ladder;



    private bool isWalking;
    private bool isClimbing;
    private bool isFishing;
    private float moveDirection; // -1 for left, 1 for right, 0 for no movement

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
        // anim.enabled = false;

        rb = GetComponent<Rigidbody2D>();

        spriteRenderer = GetComponent<SpriteRenderer>();
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
        HandleInput();

        UpdateAnimator();

        FlipSprite();

        if (Input.GetKeyDown(pauseKey))
        {
            open = true;
        }
    }

    void FixedUpdate()
    {
        if (!pauseMenu.activeSelf)
        {
            MoveCharacter();
        }
        if (open)
        {
            pauseMenu.SetActive(!pauseMenu.activeSelf);
            open = false;
        }
    }
    void HandleInput()
    {

        float horizontalInput = Input.GetAxis("Horizontal");

        moveDirection = horizontalInput;

        isWalking = Mathf.Abs(horizontalInput) > 0.1f;
        isFishing = Input.GetKeyDown(KeyCode.Space);
    }
    void UpdateAnimator()
    {
        if (!pauseMenu.activeSelf)
        {
            

            anim.SetBool("isWalking", isWalking);
            anim.SetBool("isClimbing", isClimbing);

            if (isFishing)
            {
                anim.SetTrigger("isFishing");
            }
        }
        
    }
    void FlipSprite()
    {
        if (moveDirection > 0.1f)
        {
            spriteRenderer.flipX = false;
        }
        else if (moveDirection < -0.1f)
        {
            spriteRenderer.flipX = true;
        }
    }
    void MoveCharacter()
    {
        // Calculate movement speed based on whether the player is running
        float speed = walkSpeed;

        // Apply horizontal movement
        rb.linearVelocity = new Vector2(moveDirection * speed, rb.Velocity.y);
    }
}
