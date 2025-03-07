using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    public Transform player;
    public float deadZoneLeft;
    public float deadZoneRight;
    public bool followPlayer = false;
    MoveAfterLoad moveAfterLoad;
    [HideInInspector]
    public bool camFollowPlayer = false;

    void Start()
    {
        if (player == null)
        {
            player = GameObject.Find("Player").transform;
        }

        moveAfterLoad = GameObject.Find("Player").gameObject.transform.Find("MoveOnLoad").gameObject.GetComponent<MoveAfterLoad>();
    }

    void Update()
    {
        if (followPlayer && moveAfterLoad.camFollowPlayer)
        {
            if (player.position.x >= deadZoneRight)
            {
                this.transform.position = new Vector3(deadZoneRight, this.transform.position.y, this.transform.position.z);
                camFollowPlayer = false;
            }
            else if (player.position.x <= deadZoneLeft)
            {
                this.transform.position = new Vector3(deadZoneLeft, this.transform.position.y, this.transform.position.z);
                camFollowPlayer = false;
            }
            else
            {
                this.transform.position = new Vector3(player.position.x, this.transform.position.y, this.transform.position.z);
                camFollowPlayer = true;
            }
        }
    }
}