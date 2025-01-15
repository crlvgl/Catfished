using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [Tooltip("If true, the script will target the player. If false, the script will target the camera.")]
    public bool followPlayer = true;
    private GameObject player;
    public Camera camera;
    private float offsetY;

    void Start()
    {
        if (followPlayer)
        {
            player = GameObject.Find("Player");
            offsetY = this.transform.position.y - player.transform.position.y;
        }
        else
        {
            if (camera == null)
            {   
                camera = Camera.main;
            }
            offsetY = this.transform.position.y - camera.transform.position.y;
        }
    }

    void Update()
    {
        if (followPlayer)
        {
            transform.position = new Vector3(player.transform.position.x, player.transform.position.y + offsetY, player.transform.position.z);
        }
        else
        {
            transform.position = new Vector3(camera.transform.position.x, camera.transform.position.y + offsetY, 0f);
        }
    }
}