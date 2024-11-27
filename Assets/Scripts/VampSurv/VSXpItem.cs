using UnityEngine;
using System.Collections;

public class VSXpItem : MonoBehaviour
{
    GameObject player;

    public int xpValue = 10;
    public float pickupRange = 1.0f;
    public float pickupSpeed = 1.0f;
    private bool moveNow = false;

    public nestedList[] colorValue;
    private bool rainbow = false;

    public SpriteRenderer xpRenderer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.Find("Player");

        xpRenderer = GetComponent<SpriteRenderer>();
    }

    void OnEnable()
    {
        VSPlayerHealthXp.OnPlayerDeath += OnPlayerDeath;

        Debug.Log(xpValue);
        for (int i = 0; i < colorValue.Length; i++)
        {
            if (xpValue <= colorValue[i].xpValue)
            {
                if (colorValue[i].rainbow)
                {
                    rainbow = true;
                    break;
                }
                xpRenderer.color = colorValue[i].color;
                break;
            }
            else if (xpValue > colorValue[colorValue.Length - 1].xpValue)
            {
                if (colorValue[colorValue.Length - 1].rainbow)
                {
                    rainbow = true;
                    break;
                }
                xpRenderer.color = colorValue[colorValue.Length - 1].color;
                break;
            }
        }
    }

    void OnDisable()
    {
        VSPlayerHealthXp.OnPlayerDeath -= OnPlayerDeath;
    }

    // Update is called once per frame
    void Update()
    {
        if (rainbow)
        {
            xpRenderer.color = Color.HSVToRGB(Mathf.PingPong(Time.time, 1), 1, 1);
        }

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

[System.Serializable]
public class nestedList
{
    public int xpValue;
    public Color color;
    public bool rainbow;
}