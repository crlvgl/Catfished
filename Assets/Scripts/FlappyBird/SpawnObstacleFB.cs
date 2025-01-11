using UnityEngine;
using System.Collections;

public class SpawnObstacleFB : MonoBehaviour
{
    // public GameObject pipePrefab1;
    // public GameObject pipePrefab2;
    // public GameObject pipePrefab3;
    // public GameObject pipePrefab4;
    // public GameObject pipePrefab5;
    // public GameObject pipePrefab6;
    // public GameObject pipePrefab7;
    // public GameObject pipePrefab8;
    // public GameObject pipePrefab9;
    public GameObject[] obstacleDif1;
    [Range(0, 100)]
    public int dif1Prob = 80;
    // public GameObject birdAbove;
    // public GameObject birdBelow;
    public GameObject[] obstacleDif2;
    [Range(0, 100)]
    public int dif2Prob = 10;
    // public GameObject birdBehind;
    // public GameObject birdInFront;
    public GameObject[] obstacleDif3;
    [Range(0, 100)]
    public int dif3Prob = 10;
    public float spawnRate = 2f;
    public int difficulty2 = 40;
    public int difficulty3 = 80;
    public bool spawnBirds = true;
    private int random;
    private ScoreFB scoreFB;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scoreFB = GameObject.Find("Score").gameObject.GetComponent<ScoreFB>();

        if (dif1Prob + dif2Prob + dif3Prob != 100)
        {
            float modifier = 100f / (dif1Prob + dif2Prob + dif3Prob);
            dif1Prob = Mathf.RoundToInt(dif1Prob * modifier);
            dif2Prob = Mathf.RoundToInt(dif2Prob * modifier);
            dif3Prob = Mathf.RoundToInt(dif3Prob * modifier);
            Debug.Log("Probabilities don't add up to 100. Adjusted to " + dif1Prob + ", " + dif2Prob + ", " + dif3Prob);
        }
        StartCoroutine(SpawnObstacle());
        // spawnRate = spawnRate * 5;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnObstacle()
    {
        if (!scoreFB.gameOver)
        {
            Debug.Log("Coroutine started, waiting for " + spawnRate/scoreFB.speed + "s");
            Debug.Log("Speed: " + scoreFB.speed);
            yield return new WaitForSeconds(spawnRate/scoreFB.speed);
            Debug.Log("Coroutine waited");
            if (spawnBirds)
            {
                if (scoreFB.score > difficulty3)
                {
                    random = Random.Range(0, 100);
                    if (random <= dif1Prob)
                    {
                        Instantiate(obstacleDif1[Random.Range(0, obstacleDif1.Length)], new Vector3(this.transform.position.x, Random.Range(-4.5f, 2.8f), 0), Quaternion.identity);
                    }
                    else if (random <= dif1Prob + dif2Prob)
                    {
                        Instantiate(obstacleDif2[Random.Range(0, obstacleDif2.Length)], new Vector3(this.transform.position.x, Random.Range(-4.5f, 2.8f), 0), Quaternion.identity);
                    }
                    else
                    {
                        Instantiate(obstacleDif3[Random.Range(0, obstacleDif3.Length)], new Vector3(this.transform.position.x, Random.Range(-4.5f, 2.8f), 0), Quaternion.identity);
                    }
                }
                else if (scoreFB.score > difficulty2)
                {
                    if (Random.Range(0, (dif1Prob + dif2Prob)) <= dif1Prob)
                    {
                        Instantiate(obstacleDif1[Random.Range(0, obstacleDif1.Length)], new Vector3(this.transform.position.x, Random.Range(-4.5f, 2.8f), 0), Quaternion.identity);
                    }
                    else
                    {
                        Instantiate(obstacleDif2[Random.Range(0, obstacleDif2.Length)], new Vector3(this.transform.position.x, Random.Range(-4.5f, 2.8f), 0), Quaternion.identity);
                    }
                }
                else
                {
                    Instantiate(obstacleDif1[Random.Range(0, obstacleDif1.Length)], new Vector3(this.transform.position.x, Random.Range(-4.5f, 2.8f), 0), Quaternion.identity);
                }
            }
            else
            {
                Debug.Log("new obstacle");
                Instantiate(obstacleDif1[Random.Range(0, obstacleDif1.Length)], new Vector3(this.transform.position.x, Random.Range(-4.5f, 2.8f), 0), Quaternion.identity);
            }
            Debug.Log("StartCoroutine");
            StartCoroutine(SpawnObstacle());
        }
    }
}
