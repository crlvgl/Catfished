using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    public float parallaxEffect;
    private float startpos;
    private float distance;
    private CameraFollowPlayer cameraFollowPlayer;
    private Transform player;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cameraFollowPlayer = Camera.main.GetComponent<CameraFollowPlayer>();
        player = GameObject.Find("Player").transform;

        startpos = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (cameraFollowPlayer.camFollowPlayer)
        {
            if (parallaxEffect <= 1)
            {
                distance = player.position.x * parallaxEffect;
                // Debug.Log(this.gameObject.name);
            }
            else if (parallaxEffect > 1)
            {
                distance = player.position.x * -parallaxEffect;
            }
        }

        transform.position = new Vector3(startpos + distance, transform.position.y, transform.position.z);
    }
}
