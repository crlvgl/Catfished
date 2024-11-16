using UnityEngine;

public class Disappear : MonoBehaviour
{

    public GameObject player;

    SpriteRenderer renderer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == player)
        {
            // Debug.Log("Entered");
            renderer.enabled = false;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject == player)
        {
            // Debug.Log("Exited");
            renderer.enabled = true;
        }
    }
}
