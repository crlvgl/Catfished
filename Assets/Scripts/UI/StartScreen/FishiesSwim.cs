using UnityEngine;

public class FishiesSwim : MonoBehaviour
{
    public Vector2 swimSpeed = new Vector2(1.0f, 2.0f);
    private float swimSpeedActual;
    public Vector2 hoverSpeed = new Vector2(1.0f, 2.0f);
    private float hoverSpeedActual;
    public Vector2 hoverHeight = new Vector2(1.0f, 2.0f);
    private float hoverHeightActual;

    public Vector2 returnLeft;
    private float returnLeftActual;
    public Vector2 returnRight;
    private float returnRightActual;

    void Start()
    {
        swimSpeedActual = Random.Range(swimSpeed.x, swimSpeed.y);
        hoverSpeedActual = Random.Range(hoverSpeed.x, hoverSpeed.y);
        hoverHeightActual = Random.Range(hoverHeight.x, hoverHeight.y);
        returnLeftActual = Random.Range(returnLeft.x, returnLeft.y);
        returnRightActual = Random.Range(returnRight.x, returnRight.y);
    }

    void Update()
    {
        if (this.transform.position.x < returnLeftActual)
        {
            swimSpeedActual = Mathf.Abs(swimSpeedActual);
            this.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (this.transform.position.x > returnRightActual)
        {
            swimSpeedActual = -Mathf.Abs(swimSpeedActual);
            this.transform.rotation = Quaternion.Euler(0, 180, 0);
        }

        this.transform.position += new Vector3(swimSpeedActual * Time.deltaTime, Mathf.Sin(Time.time * hoverSpeedActual) * hoverHeightActual * Time.deltaTime, 0);
    }
}