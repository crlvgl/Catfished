using UnityEngine;

public class Projectile : MonoBehaviour
{
    public string deathName = "Death";
    public float speedMin = 2f;
    public float speedMax = 8f;
    public GameObject player;
    SpriteRenderer playerColor;
    private Color oldColor;
    private Color newColor;
    private float speedX;
    private float speedY;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.Find("Player");
        playerColor = player.GetComponent<SpriteRenderer>();
        speedX = Random.Range(speedMin, speedMax);
        speedY = Random.Range(speedMin, speedMax);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += new Vector3(speedX * Time.deltaTime, speedY * Time.deltaTime, 0);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == player)
        {
            oldColor = playerColor.color;
            float red = oldColor.r;
            float green = oldColor.g;
            newColor = new Color(red+0.1f, green-0.1f, 0);
            playerColor.color = newColor;
            if (newColor.r >= 1)
            {
                Destroy(player);
            }
            Destroy(this.gameObject);
        }

        else if (other.gameObject.name == deathName)
        {
            Destroy(this.gameObject);
        }
    }
}
