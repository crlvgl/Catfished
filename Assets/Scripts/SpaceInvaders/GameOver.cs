using UnityEngine;

public class GameOver : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    private float nextDamage = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            if (Time.time >= nextDamage)
            {
                nextDamage = Time.time + 1f;
                PlayerHealth.health -= 1;
                spriteRenderer.color = new Color(1f, 0f, 0f, 0.5f);
            }
        }
    }
}
