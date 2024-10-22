using UnityEngine;

public class Ladder : MonoBehaviour
{
    public GameObject player;
    public static bool isOnLadder;
    float startGrav;
    Rigidbody2D playerBody;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerBody = player.GetComponent<Rigidbody2D>();
        startGrav = playerBody.gravityScale;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == player)
        {
            Debug.Log("Entered");
            isOnLadder = true;
            playerBody.gravityScale = 0;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject == player)
        {
            Debug.Log("Exited");
            isOnLadder = false;
            playerBody.gravityScale = startGrav;
        }
    }
}
