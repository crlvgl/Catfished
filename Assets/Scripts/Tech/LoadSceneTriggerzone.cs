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
    public float waitTime = 0.2f;

    void Start()
    {

    }

    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            StartCoroutine(LoadScene());
        }
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