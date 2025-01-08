using UnityEngine;

public class MoveEnemies : MonoBehaviour
{
    public float speed = 5.0f;
    public bool moveRight = true;
    public float moveDown = 1.0f;
    private bool moveDownBool = true;
    public float screenWidth = 23.0f;
    private float nextMovement = 0f;
    public float movementRate = 1.0f;

    private PlayerHealth playerHealthSI;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerHealthSI = GameObject.Find("Player").gameObject.GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerHealthSI.health > 0)
        {
            if (moveRight && Time.time > nextMovement)
            {
                transform.position += Vector3.right * speed;
                nextMovement = Time.time + movementRate;

                if (transform.position.x >= screenWidth && moveDownBool)
                {
                    moveDownBool = false;
                    moveRight = false;
                    transform.position += Vector3.down * moveDown;
                }
            }
            else if (!moveRight && Time.time > nextMovement)
            {
                transform.position += Vector3.left * speed;
                nextMovement = Time.time + movementRate;

                if (transform.position.x <= -screenWidth && moveDownBool)
                {
                    moveDownBool = false;
                    moveRight = true;
                    transform.position += Vector3.down * moveDown;
                }
            }

            if (moveDownBool == false && transform.position.x < 2 && transform.position.x > -2)
            {
                moveDownBool = true;
            }
        }
    }
}
