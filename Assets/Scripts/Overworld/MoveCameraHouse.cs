using UnityEngine;
using System.Collections;

public class MoveCameraHouse : MonoBehaviour
{
    public Camera cam;
    public Vector3 positionLeft;
    public Vector3 positionRight;
    public float moveTime = 1.0f;
    private bool moveCamera = false;
    private bool moveRight = false;
    private bool moveLeft = false;
    private Vector3 startPos;
    private float elapsedTime;
    public bool followPlayerRight = false;
    public bool followPlayerLeft = false;
    public float waitTime = 0.0f;

    void Start()
    {
        if (cam == null)
        {
            cam = Camera.main;
        }
    }

    void Update()
    {
        if (moveCamera)
        {
            if (moveRight)
            {
                elapsedTime += Time.deltaTime;
                float t = Mathf.Clamp01(elapsedTime / moveTime);
                cam.transform.position = Vector3.Lerp(startPos, positionRight, t);

                if (t >= 1.0f)
                {
                    moveRight = false;
                    elapsedTime = 0.0f;
                    moveCamera = false;
                    if (followPlayerRight)
                    {
                        StartCoroutine(stallFollowPlayer());
                    }
                }
            }
            else if (moveLeft)
            {
                elapsedTime += Time.deltaTime;
                float t = Mathf.Clamp01(elapsedTime / moveTime);
                cam.transform.position = Vector3.Lerp(startPos, positionLeft, t);

                if (t >= 1.0f)
                {
                    moveLeft = false;
                    elapsedTime = 0.0f;
                    moveCamera = false;
                    if (followPlayerLeft)
                    {
                        StartCoroutine(stallFollowPlayer());
                    }
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            cam.GetComponent<CameraFollowPlayer>().followPlayer = false;
            moveCamera = true;
            startPos = cam.transform.position;
            if (cam.transform.position == positionLeft)
            {
                moveRight = true;
            }
            else if (cam.transform.position == positionRight)
            {
                moveLeft = true;
            }
        }
    }

    IEnumerator stallFollowPlayer()
    {
        yield return new WaitForSeconds(waitTime);
        cam.GetComponent<CameraFollowPlayer>().followPlayer = true;
    }
}