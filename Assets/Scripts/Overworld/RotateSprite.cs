using UnityEngine;

public class RotateSprite : MonoBehaviour
{
    public float rotationSpeed = 1f;
    public enum Direction
    {
        clockwise,
        counterclockwise
    }
    public Direction rotationDirection;
    private float t;

    void Start()
    {

    }

    void Update()
    {
        t += Time.deltaTime * rotationSpeed;
        if (rotationDirection == Direction.clockwise)
        {
            this.transform.rotation = Quaternion.Euler(0, 0, t);
        }
        else if (rotationDirection == Direction.counterclockwise)
        {
            this.transform.rotation = Quaternion.Euler(0, 0, -t);
        }

        if (Input.anyKeyDown || Input.GetMouseButtonDown(0))
        {
            GameObject.Find("Player").GetComponent<PlayerMovement>().enabled = true;
            Destroy(GameObject.Find("FishAnim"));
            Destroy(this.gameObject);
        }
        
    }
}