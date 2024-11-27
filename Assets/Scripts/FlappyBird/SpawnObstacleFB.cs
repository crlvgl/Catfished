using UnityEngine;
using System.Collections;

public class SpawnObstacleFB : MonoBehaviour
{
    public GameObject pipePrefab1;
    public GameObject pipePrefab2;
    public GameObject pipePrefab3;
    public GameObject pipePrefab4;
    public GameObject pipePrefab5;
    public GameObject pipePrefab6;
    public GameObject pipePrefab7;
    public GameObject pipePrefab8;
    public GameObject pipePrefab9;
    public GameObject birdAbove;
    public GameObject birdBelow;
    public GameObject birdBehind;
    public GameObject birdInFront;
    public float spawnRate = 2f;
    public int difficulty2 = 40;
    public bool spawnBirds = true;
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
            if (spawnBirds)
            {
                if (ScoreFB.score > difficulty2)
                {
                    random = Random.Range(0, 8);
                }
                else
                {
                    random = Random.Range(0, 6);
                }
            }
            else
            {
                random = 1;
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
                int randomPipe = Random.Range(0, 9);
                if (randomPipe == 0)
                {
                    Instantiate(pipePrefab1, new Vector3(this.transform.position.x, Random.Range(-3f, 3f), 0), Quaternion.identity);
                }
                else if (randomPipe == 1)
                {
                    Instantiate(pipePrefab2, new Vector3(this.transform.position.x, Random.Range(-3f, 3f), 0), Quaternion.identity);
                }
                else if (randomPipe == 2)
                {
                    Instantiate(pipePrefab3, new Vector3(this.transform.position.x, Random.Range(-3f, 3f), 0), Quaternion.identity);
                }
                else if (randomPipe == 3)
                {
                    Instantiate(pipePrefab4, new Vector3(this.transform.position.x, Random.Range(-3f, 3f), 0), Quaternion.identity);
                }
                else if (randomPipe == 4)
                {
                    Instantiate(pipePrefab5, new Vector3(this.transform.position.x, Random.Range(-3f, 3f), 0), Quaternion.identity);
                }
                else if (randomPipe == 5)
                {
                    Instantiate(pipePrefab6, new Vector3(this.transform.position.x, Random.Range(-3f, 3f), 0), Quaternion.identity);
                }
                else if (randomPipe == 6)
                {
                    Instantiate(pipePrefab7, new Vector3(this.transform.position.x, Random.Range(-3f, 3f), 0), Quaternion.identity);
                }
                else if (randomPipe == 7)
                {
                    Instantiate(pipePrefab8, new Vector3(this.transform.position.x, Random.Range(-3f, 3f), 0), Quaternion.identity);
                }
                else
                {
                    Instantiate(pipePrefab9, new Vector3(this.transform.position.x, Random.Range(-3f, 3f), 0), Quaternion.identity);
                }
            }
            StartCoroutine(SpawnObstacle());
        }
    }
}
