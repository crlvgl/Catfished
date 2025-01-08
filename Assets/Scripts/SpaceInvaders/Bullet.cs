using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 25.0f;
    public string deathName = "Death";
    private TimerScore timerScoreSI;
    private PlayerHealth playerHealthSI;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timerScoreSI = GameObject.Find("Timer").gameObject.GetComponent<TimerScore>();
        playerHealthSI = GameObject.Find("Player").gameObject.GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += new Vector3(0, speed * Time.deltaTime, 0);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Destroy(other.gameObject);
            timerScoreSI.score += 36 * playerHealthSI.health;
            Destroy(this.gameObject);
        }

        else if (other.gameObject.name == deathName)
        {
            Destroy(this.gameObject);
        }
    }
}
