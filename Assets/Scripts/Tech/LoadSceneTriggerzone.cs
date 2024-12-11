using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadSceneTriggerzone : MonoBehaviour
{
    [Tooltip("The path to the scene to load")]
    public string scenePath = "Assets/Scenes/exampleScene.unity";
    [Tooltip("The path to the loading screen scene. DO NOT TOUCH UNLESS YOU KNOW WHAT YOU'RE DOING")]
    public string loadingScreenPath = "Assets/Scenes/LoadingScreen.unity";
    [Tooltip("The time to wait before loading the scene. If set to 0, the scene will load immediately")]
    public KeyCode pressedKey = KeyCode.Space;
    public float waitTime = 0.2f;

    private bool canLoad = false;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(pressedKey))
        {
            // Debug.Log("Button has been pressed");
            canLoad = true;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // TODO
        // add some pop-up text to show the player that they can press a key to load the scene
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            // Debug.Log("Player has entered the trigger zone");
            if (canLoad)
            {
                canLoad = false;
                Debug.Log("Loading scene: " + scenePath);
                StartCoroutine(LoadScene());
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        // TODO
        // remove the pop-up text
    }

    IEnumerator LoadScene()
    {
        staticBackbone.sceneToLoad = scenePath;

        yield return new WaitForSeconds(waitTime);

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(loadingScreenPath);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}