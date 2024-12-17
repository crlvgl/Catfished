using UnityEngine;
using System.Collections;

public class StartMoveCamera : MonoBehaviour
{
    public Vector3 targetPos;
    public float movementTime = 1.0f;
    public float wiggleTime = 0.1f;
    public float wiggleAmount = 0.1f;

    public GameObject buttonText;

    private bool hasStarted = false;
    private bool moveCamera1 = false;
    private bool moveCamera2 = false;
    private bool moveCamera3 = false;

    private Vector3 startPos;
    private float elapsedTime;
    
    void Start()
    {

    }

    void Update()
    {
        if (Input.anyKeyDown && !hasStarted)
        {
            Debug.Log("Camera has started moving");
            buttonText.SetActive(false);
            hasStarted = true;
            startPos = transform.position;
            moveCamera1 = true;
        }
        if (moveCamera1)
        {
            elapsedTime += Time.deltaTime;
            
            float t  = Mathf.Clamp01(elapsedTime / wiggleTime);

            transform.position = Vector3.Lerp(startPos, startPos + new Vector3(0, wiggleAmount, 0), t);

            if (t >= 1.0f)
            {
                moveCamera1 = false;
                startPos = transform.position;
                elapsedTime = 0.0f;
                moveCamera2 = true;
            }
        }
        else if (moveCamera2)
        {
            elapsedTime += Time.deltaTime;
            
            float t  = Mathf.Clamp01(elapsedTime / movementTime);

            transform.position = Vector3.Lerp(startPos, targetPos - new Vector3(0, wiggleAmount, 0), t);

            if (t >= 1.0f)
            {
                moveCamera2 = false;
                startPos = transform.position;
                elapsedTime = 0.0f;
                moveCamera3 = true;
            }
        }
        else if (moveCamera3)
        {
            elapsedTime += Time.deltaTime;
            
            float t  = Mathf.Clamp01(elapsedTime / wiggleTime);

            transform.position = Vector3.Lerp(startPos, targetPos, t);

            if (t >= 1.0f)
            {
                moveCamera3 = false;
            }
        }
    }
}