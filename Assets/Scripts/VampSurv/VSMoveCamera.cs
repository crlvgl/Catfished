using UnityEngine;

public class VSMoveCamera : MonoBehaviour
{
    public GameObject player;

    public float adjustX = 0.0f;
    public float adjustY = 0.15f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (player == null)
        {
            player = GameObject.Find("Player");
        }
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
        this.transform.position = new Vector3(player.transform.position.x + adjustX, player.transform.position.y + adjustY, this.transform.position.z);
    }

    void OnPlayerDeath()
    {
        this.enabled = false;
    }
}
