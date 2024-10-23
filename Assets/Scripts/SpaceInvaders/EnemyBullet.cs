using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed = 25.0f;
    public string deathName = "Death";

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += new Vector3(0, -speed * Time.deltaTime, 0);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            PlayerHealth.health -= 1;
            if (TimerScore.score > 500)
            {
                TimerScore.score -= 500;
            }
            else if (TimerScore.score <= 500)
            {
                TimerScore.score = 0;
            }
            Destroy(this.gameObject);
        }

        else if (other.gameObject.name == deathName)
        {
            Destroy(this.gameObject);
        }
    }
}
