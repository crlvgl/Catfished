using UnityEngine;
using System.Collections;

public class LavaBubbles : MonoBehaviour
{
    public GameObject[] lavaBubbles;
    public Vector2 spawnRate = new Vector2(1, 3);
    public Collider2D col;

    void Start()
    {
        if (col == null)
        {
            col = GetComponent<Collider2D>();
        }

        StartCoroutine(spawnInsideCol());
    }

    IEnumerator spawnInsideCol()
    {
        Vector2 spawnPos = new Vector2(Random.Range(col.bounds.min.x, col.bounds.max.x), Random.Range(col.bounds.min.y, col.bounds.max.y));
        GameObject lavaBubble = lavaBubbles[Random.Range(0, lavaBubbles.Length)];
        Instantiate(lavaBubble, spawnPos, Quaternion.identity);
        yield return new WaitForSeconds(Random.Range(spawnRate.x, spawnRate.y));
        StartCoroutine(spawnInsideCol());
    }
}