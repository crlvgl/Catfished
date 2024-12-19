using UnityEngine;

public class MoveObstaclesFB : MonoBehaviour
{
    public float backgroundSlowdown = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Score").gameObject.GetComponent<ScoreFB>().gameOver)
        {
            return;
        }
        this.transform.position += Vector3.left * (GameObject.Find("Score").gameObject.GetComponent<ScoreFB>().speed - backgroundSlowdown) * Time.deltaTime;
    }
}
