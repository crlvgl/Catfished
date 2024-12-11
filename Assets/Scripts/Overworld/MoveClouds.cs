using UnityEngine;

public class MoveClouds : MonoBehaviour
{
    public float speed = 0.1f;
    public bool moveRight = true;

    public float destroyPoint = 10.0f;

    void Start()
    {
        if (!moveRight)
        {
            speed *= -1;
        }
    }

    void Update()
    {
        transform.position += new Vector3(speed * Time.deltaTime, 0, 0);

        if (moveRight && transform.position.x > destroyPoint)
        {
            Destroy(this.gameObject);
        }
        else if (!moveRight && transform.position.x < -destroyPoint)
        {
            Destroy(this.gameObject);
        }
    }
}