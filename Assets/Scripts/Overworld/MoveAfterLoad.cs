using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveAfterLoad : MonoBehaviour
{
    private Transform playerTransform;
    public bool camFollowPlayer = false;

    void Start()
    {
        if (staticBackbone.moveCharacterNow)
        {
            if (GameObject.Find("Player") != null)
            {
                playerTransform = GameObject.Find("Player").transform;
                playerTransform.position = new Vector3(staticBackbone.playerPositionX, playerTransform.position.y, playerTransform.position.z);
            }
            staticBackbone.moveCharacterNow = false;

            if (SceneManager.GetActiveScene().name == "House")
            {
                camFollowPlayer = false;
                
                if (staticBackbone.playerPositionX < -2.921)
                {
                    Camera.main.GetComponent<CameraFollowPlayer>().followPlayer = false;
                    Camera.main.transform.position = new Vector3(-5.941f, 0f, -10f);
                }
                else if (staticBackbone.playerPositionX > -2.921 && staticBackbone.playerPositionX < 2.909)
                {
                    Camera.main.GetComponent<CameraFollowPlayer>().followPlayer = false;
                    Camera.main.transform.position = new Vector3(0f, 0f, -10f);
                }
                else if (staticBackbone.playerPositionX > 2.909)
                {
                    Camera.main.transform.position = new Vector3(5.94f, 0f, -10f);
                    Camera.main.GetComponent<CameraFollowPlayer>().followPlayer = true;
                }

                camFollowPlayer = true;
            }
        }

        else
        {
            camFollowPlayer = true;
        }
    }
}