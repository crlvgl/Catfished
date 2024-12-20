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

    public bool moveCharacter = false;
    public bool moveCharacterRight = false;
    public GameObject[] restraintCollider;
    private bool moveCharacterNow = false;
    public bool fadeToBlack = false;
    private bool fadeToBlackNow = false;
    public float timeBeforeFade = 0.5f;
    public SpriteRenderer blackScreen;
    public float fadeSpeed = 1.0f;
    private Camera cam;
    private Vector3 camPos;

    public GameObject player;

    private bool canLoad = false;
    private bool loading = false;

    void Start()
    {
        if (player == null)
        {
            player = GameObject.Find("Player");
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(pressedKey) && canLoad && !loading)
        {
            // Debug.Log("Button has been pressed");
            loading = true;
            canLoad = false;
            cam = Camera.main;
            camPos = cam.transform.position;
            Debug.Log("Loading scene: " + scenePath);
            StartCoroutine(LoadScene());
        }

        if (moveCharacterNow)
        {
            if (moveCharacterRight)
            {
                player.transform.position = Vector3.MoveTowards(player.transform.position, new Vector3(player.transform.position.x + 20, player.transform.position.y, player.transform.position.z), player.GetComponent<PlayerMovement>().speed * Time.deltaTime);
            }
            else
            {
                player.transform.position = Vector3.MoveTowards(player.transform.position, new Vector3(player.transform.position.x - 20, player.transform.position.y, player.transform.position.z), player.GetComponent<PlayerMovement>().speed * Time.deltaTime);
            }
            cam.transform.position = camPos;
        }

        if (fadeToBlackNow && blackScreen.color.a < 1)
        {
            blackScreen.color = new Color(0.0f, 0.0f, 0.0f, blackScreen.color.a + Time.deltaTime / fadeSpeed);
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
            canLoad = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        // TODO
        // remove the pop-up text
        canLoad = false;
    }

    IEnumerator LoadScene()
    {
        if (moveCharacter)
        {
            foreach (GameObject restraint in restraintCollider)
            {
                Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), restraint.GetComponent<Collider2D>());
            }
            moveCharacterNow = true;
        }

        if (fadeToBlack)
        {
            yield return new WaitForSeconds(timeBeforeFade);
            fadeToBlackNow = true;
        }
        
        staticBackbone.sceneToLoad = scenePath;

        yield return new WaitForSeconds(waitTime);

        StartCoroutine(LoadSceneAsync());
    }

    IEnumerator LoadSceneAsync()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(loadingScreenPath);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
