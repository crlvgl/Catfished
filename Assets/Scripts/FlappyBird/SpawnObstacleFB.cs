using UnityEngine;
using System.Collections;

public class SpawnObstacleFB : MonoBehaviour
{
    public GameObject pipePrefab;
    public GameObject birdAbove;
    public GameObject birdBelow;
    public GameObject birdBehind;
    public GameObject birdInFront;
    public float spawnRate = 2f;
    public int difficulty2 = 40;
    private int random;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SpawnObstacle());
        spawnRate = spawnRate * 5;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnObstacle()
    {
        if (!ScoreFB.gameOver)
        {
            yield return new WaitForSeconds(spawnRate/ScoreFB.speed);
            if (ScoreFB.score > difficulty2)
            {
                random = Random.Range(0, 8);
            }
            else
            {
                random = Random.Range(0, 6);
            }
            if (random == 4)
            {
                Instantiate(birdAbove, new Vector3(this.transform.position.x, Random.Range(-4.5f, 2.8f), 0), Quaternion.identity);
            }
            else if (random == 5)
            {
                Instantiate(birdBelow, new Vector3(this.transform.position.x, Random.Range(-2.8f, 4.5f), 0), Quaternion.identity);
            }
            else if (random == 6)
            {
                Instantiate(birdBehind, new Vector3(this.transform.position.x, Random.Range(-4.3f, 4.3f), 0), Quaternion.identity);
            }
            else if (random == 7)
            {
                Instantiate(birdInFront, new Vector3(this.transform.position.x, Random.Range(-4.3f, 4.3f), 0), Quaternion.identity);
            }
            else
            {
                Instantiate(pipePrefab, new Vector3(this.transform.position.x, Random.Range(-3f, 3f), 0), Quaternion.identity);
            }
            StartCoroutine(SpawnObstacle());
        }
    }
}
