using UnityEngine;

public class MoveObstaclesFB : MonoBehaviour
{
    public float backgroundSlowdown = 0f;

    private ScoreFB scoreFB;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scoreFB = GameObject.Find("Score").gameObject.GetComponent<ScoreFB>();
    }

    // Update is called once per frame
    void Update()
    {
        if (scoreFB.gameOver)
        {
            return;
        }
        this.transform.position += Vector3.left * (scoreFB.speed - backgroundSlowdown) * Time.deltaTime;
    }
}
