using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadMinigame : MonoBehaviour
{
    public string pathToMinigame = "Assets/Scenes/MiniGames/ExampleMinigame.unity";
    public KeyCode actionKey = KeyCode.Space;
    private bool startLoadingNow = false;
    private bool loading = false;
    private bool canLoad = false;

    public GameObject animScreen;
    public float yPosition = 0.0f;
    public float speed = 1.0f;

    void Start()
    {

    }

    void Update()
    {
        if  (Input.GetKeyDown(actionKey) && !loading && canLoad)
        {
            startLoadingNow = true;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            canLoad = true;
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            if (startLoadingNow)
            {
                startLoadingNow = false;
                loading = true;
                Debug.Log("Loading Minigame");
                StartCoroutine(LoadScene());
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            canLoad = false;
        }
    }

    IEnumerator LoadScene()
    {
        while (animScreen.transform.position.y < yPosition)
        {
            animScreen.transform.position = new Vector3(animScreen.transform.position.x, animScreen.transform.position.y + Time.deltaTime * speed, animScreen.transform.position.z);
            yield return null;
        }

        staticBackbone.sceneToReturnTo = SceneManager.GetActiveScene().path;

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(pathToMinigame);
        
        staticBackbone.sceneToLoad = null;

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}