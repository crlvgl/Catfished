using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private GameObject player;
    private float offsetY;

    void Start()
    {
        player = GameObject.Find("Player");
        offsetY = this.transform.position.y - player.transform.position.y;
    }

    void Update()
    {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y + offsetY, player.transform.position.z);
    }
}