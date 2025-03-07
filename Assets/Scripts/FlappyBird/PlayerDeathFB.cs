using UnityEngine;

public class PlayerDeathFB : MonoBehaviour
{
    private ScoreFB scoreFB;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scoreFB = GameObject.Find("Score").gameObject.GetComponent<ScoreFB>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            Destroy(other.gameObject);
            Debug.Log("Player has died");
            scoreFB.gameOver = true;
        }
        else if (other.gameObject.name == "Death")
        {
            Destroy(this.transform.parent.gameObject);
        }
    }
}
