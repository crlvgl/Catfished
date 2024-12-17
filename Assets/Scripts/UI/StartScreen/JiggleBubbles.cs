using UnityEngine;

public class JiggleBubbles : MonoBehaviour
{
    public float movementSpeed = 1.0f;
    public float jiggleDistance = 0.1f;
    public float jiggleSpeed = 1.0f;
    private float startPosX;
    private float elapsedTime = 0.0f;

    void Start()
    {
        startPosX = this.transform.position.x;
    }

    void Update()
    {
        elapsedTime += Time.deltaTime;

        this.transform.position = new Vector3(startPosX + Mathf.Sin(elapsedTime * jiggleSpeed) * jiggleDistance, this.transform.position.y + movementSpeed * Time.deltaTime, this.transform.position.z);
    }
}