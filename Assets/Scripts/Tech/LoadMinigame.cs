using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadMinigame : MonoBehaviour
{
    public string pathToMinigame = "Assets/Scenes/MiniGames/ExampleMinigame.unity";
    public KeyCode actionKey = KeyCode.Space;
    private bool loading = false;
    private bool canLoad = false;

    public GameObject animScreen;
    public float yPosition = 0.0f;
    public float speed = 1.0f;

    public bool showFishingIndicator = false;
    public GameObject fishingIndicator;
    public float fadeModifier = 1.0f;
    public Animator anim;
    public bool fishLeft = false;

    void Start()
    {
        if (showFishingIndicator)
        {
            fishingIndicator.SetActive(false);
        }
    }

    void Update()
    {
        if  (Input.GetKeyDown(actionKey) && !loading && canLoad)
        {
            loading = true;
            Debug.Log("Loading Minigame");
            StartCoroutine(LoadScene());
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            Debug.Log("Entered Minigame Area");
            if (showFishingIndicator)
            {
                StartCoroutine(ShowIndicator());
            }
            canLoad = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            Debug.Log("Left Minigame Area");
            if (showFishingIndicator)
            {
                StartCoroutine(HideIndicator());
            }
            canLoad = false;
        }
    }

    IEnumerator LoadScene()
    {
        GameObject player = GameObject.Find("Player");
        Destroy(player.GetComponent<Rigidbody2D>());
        Destroy(player.GetComponent<Collider2D>());
        player.GetComponent<PlayerMovement>().enabled = false;
        if (fishLeft)
        {
            Debug.Log("turned Player Left");
            player.transform.position = new Vector3(player.transform.position.x - 0.862f, player.transform.position.y - 0.1505f, player.transform.position.z);
            player.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else if (!fishLeft)
        {
            Debug.Log("turned Player Right");
            player.transform.position = new Vector3(player.transform.position.x + 0.862f, player.transform.position.y - 0.1505f, player.transform.position.z);
            player.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        anim.SetBool("Fish", true);
        SoundEffectManager.Play("Swish", true, 1.5f);
        yield return new WaitForSeconds(7.5f);
        SoundEffectManager.Play("Blub", false, 0f);
        StartCoroutine(MoveScreen());
    }

    IEnumerator MoveScreen()
    {
        while (animScreen.transform.position.y < yPosition)
        {
            animScreen.transform.position = new Vector3(animScreen.transform.position.x, animScreen.transform.position.y + Time.deltaTime * speed, animScreen.transform.position.z);
            yield return null;
        }
        StartCoroutine(LoadSceneAsync());
    }

    IEnumerator LoadSceneAsync()
    {
        staticBackbone.sceneToReturnTo = SceneManager.GetActiveScene().path;

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(pathToMinigame);
        
        staticBackbone.sceneToLoad = null;

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }

    IEnumerator ShowIndicator()
    {
        fishingIndicator.SetActive(true);
        while (fishingIndicator.GetComponent<SpriteRenderer>().color.a < 1)
        {
            fishingIndicator.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, fishingIndicator.GetComponent<SpriteRenderer>().color.a + Time.deltaTime * fadeModifier);
            yield return null;
        }
    }

    IEnumerator HideIndicator()
    {
        while (fishingIndicator.GetComponent<SpriteRenderer>().color.a > 0)
        {
            fishingIndicator.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, fishingIndicator.GetComponent<SpriteRenderer>().color.a - Time.deltaTime * fadeModifier);
            yield return null;
        }
        fishingIndicator.SetActive(false);
    }
}