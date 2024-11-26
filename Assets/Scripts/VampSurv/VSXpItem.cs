using UnityEngine;
using System.Collections;

public class VSXpItem : MonoBehaviour
{
    GameObject player;

    public int xpValue = 10;
    public float pickupRange = 1.0f;
    public float pickupSpeed = 1.0f;
    private bool moveNow = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.Find("Player");
    }

    void OnEnable()
    {
        VSPlayerHealthXp.OnPlayerDeath += OnPlayerDeath;
    }

    void OnDisable()
    {
        VSPlayerHealthXp.OnPlayerDeath -= OnPlayerDeath;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < pickupRange && !moveNow)
        {
            moveNow = true;
        }

        if (moveNow)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, pickupSpeed * Time.deltaTime);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Debug.Log("Player picks up XP");
            player.GetComponent<VSPlayerHealthXp>().playerXp += xpValue;
            Destroy(this.gameObject);
        }
    }

    void OnPlayerDeath()
    {
        this.enabled = false;
    }
}