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
    private float startpos;
    private float distance;

    private CameraFollowPlayer cameraFollowPlayer;
    private Transform player;

    void Start()
    {
        cameraFollowPlayer = Camera.main.GetComponent<CameraFollowPlayer>();
        player = GameObject.Find("Player").transform;

        if (!moveRight)
        {
            speed *= -1;
        }

        startpos = transform.position.x;
    }

    void Update()
    {
        startpos += speed * Time.deltaTime;

        if (cameraFollowPlayer.camFollowPlayer)
        {
            if (parallaxEffect <= 1)
            {
                distance = player.position.x * parallaxEffect;
            }
            else if (parallaxEffect > 1)
            {
                distance = player.position.x * -parallaxEffect;
            }
        }
        else
        {
            distance = 0;
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
