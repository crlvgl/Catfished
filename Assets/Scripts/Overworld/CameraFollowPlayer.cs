using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    public Transform player;
    public float deadZoneLeft;
    public float deadZoneRight;
    public bool followPlayer = false;

    void Start()
    {
        if (player == null)
        {
            player = GameObject.Find("Player").transform;
        }
    }

    void Update()
    {
        if (followPlayer)
        {
            if (player.position.x >= deadZoneRight)
            {
                this.transform.position = new Vector3(deadZoneRight, this.transform.position.y, this.transform.position.z);
            }
            else if (player.position.x <= deadZoneLeft)
            {
                this.transform.position = new Vector3(deadZoneLeft, this.transform.position.y, this.transform.position.z);
            }
            else
            {
                this.transform.position = new Vector3(player.position.x, this.transform.position.y, this.transform.position.z);
            }
        }
    }
}