using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class UIButtons : MonoBehaviour
{
    public enum ButtonFunction
    {
        Load,
        New,
        Exit,
        Freeplay,
        Save,
        ToTitleScreen,
        ContinueGame
    }
    [Header("Button Function")]
    [Tooltip("Function of the button")]
    public ButtonFunction buttonOptions;
    private string functionOfButton;
    [Header("Scene Settings")]
    [Tooltip("Path to the first scene of the game")]
    public string pathToFirstScene = "Assets/Scenes/Overworld/FieldTest.unity";
    [Tooltip("Path to the loading screen")]
    public string pathToLoadingScreen = "Assets/Scenes/LoadingScreen.unity";
    [Tooltip("Path to the title screen")]
    public string pathToTitleScreen = "Assets/Scenes/StartScreen.unity";
    [Header("Optional Settings")]
    [Tooltip("Time to wait before loading the scene; if 0, loads immediately")]
    public float waitTime = 0.1f;

    [Header("Sprite Settings")]
    public Sprite mouseOver;
    private SpriteRenderer spriteRenderer;
    private Sprite defaultSprite;

    void Start()
    {
        functionOfButton = buttonOptions.ToString().ToLower();
        spriteRenderer = GetComponent<SpriteRenderer>();
        defaultSprite = spriteRenderer.sprite;
    }

    void OnMouseEnter()
    {
        spriteRenderer.sprite = mouseOver;
    }

    void OnMouseDown()
    {
        switch (functionOfButton)
        {
            case "load":
                break;
            case "new":
                staticBackbone.sceneToLoad = pathToFirstScene;
                StartCoroutine(LoadScene(pathToLoadingScreen));
                break;
            case "exit":
                Application.Quit();
                Debug.Log("Application has quit");
                break;
            case "freeplay":
                break;
            case "save":
                break;
            case "totitlescreen":
                staticBackbone.sceneToLoad = pathToTitleScreen;
                StartCoroutine(LoadScene(pathToLoadingScreen));
                break;
            case "continuegame":
                this.transform.parent.gameObject.SetActive(false);
                break;
        }
    }

    void OnMouseExit()
    {
        spriteRenderer.sprite = defaultSprite;
    }

    IEnumerator LoadScene(string SceneToLoad)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(SceneToLoad);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}