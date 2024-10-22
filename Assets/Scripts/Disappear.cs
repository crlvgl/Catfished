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
            renderer.enabled = false;
        }
        Debug.Log("Entered");
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject == player)
        {
            renderer.enabled = true;
        }
        Debug.Log("Exited");
    }
}
