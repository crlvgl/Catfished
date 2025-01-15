using UnityEngine;

public class MoveClouds : MonoBehaviour
{
    [Header("Movement")]
    public float speed = 0.1f;
    public bool moveRight = true;

    public float destroyPoint = 10.0f;

    [Header("Parallax Effect")]
    [Tooltip("strength of the parallax effect")]
    public float parallaxEffect;
    public Camera cam;
    private float startpos;
    private float distance;

    void Start()
    {
        if (cam == null)
        {
            cam = Camera.main;
        }

        if (!moveRight)
        {
            speed *= -1;
        }

        startpos = transform.position.x;
    }

    void Update()
    {
        startpos += speed * Time.deltaTime;

        if (parallaxEffect <= 1)
        {
            Vector3 camPos = cam.transform.position;
            distance = camPos.x * parallaxEffect;
        }
        else if (parallaxEffect > 1)
        {
            Vector3 camPos = cam.transform.position;
            distance = camPos.x * -parallaxEffect;
        }

        transform.position = new Vector3(startpos + distance, this.transform.position.y, this.transform.position.z);

        // if (this.gameObject.name == "Clouds")
        // {
        //     Debug.Log(this.transform.position.x);
        //     Debug.Log(this.transform.position.x > destroyPoint);
        // }

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
