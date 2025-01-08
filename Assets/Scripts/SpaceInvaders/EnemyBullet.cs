using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed = 25.0f;
    public string deathName = "Death";
    private TimerScore timerScoreSI;
    private PlayerHealth playerHealthSI;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerHealthSI = GameObject.Find("Player").gameObject.GetComponent<PlayerHealth>();
        timerScoreSI = GameObject.Find("Timer").gameObject.GetComponent<TimerScore>();
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
            playerHealthSI.health -= 1;
            if (timerScoreSI.score > 500)
            {
                timerScoreSI.score -= 500;
            }
            else if (timerScoreSI.score <= 500)
            {
                timerScoreSI.score = 0;
            }
            Destroy(this.gameObject);
        }

        else if (other.gameObject.name == deathName)
        {
            Destroy(this.gameObject);
        }
    }
}
