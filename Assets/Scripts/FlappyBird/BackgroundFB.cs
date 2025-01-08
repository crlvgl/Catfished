using UnityEngine;
using System.Collections;

public class BackgroundFB : MonoBehaviour
{
    public SpriteRenderer backgroundSprite;
    private float width;
    public float destroyX = -46f;
    private bool hasSpawned = false;
    private ScoreFB scoreFB;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (backgroundSprite == null)
        {
            backgroundSprite = GetComponent<SpriteRenderer>();
        }

        width = backgroundSprite.bounds.size.x;

        scoreFB = GameObject.Find("Score").gameObject.GetComponent<ScoreFB>();
    }

    // Update is called once per frame
    void Update()
    {
        if (scoreFB.gameOver)
        {
            return;
        }
        if (this.transform.position.x < destroyX)
        {
            Destroy(this.gameObject);
        }
        if (this.transform.position.x < 0 && !hasSpawned)
        {
            hasSpawned = true;
            Instantiate(this.gameObject, new Vector3(this.transform.position.x + width - 0.1f, this.transform.position.y, 0), Quaternion.identity);
        }
    }
}
