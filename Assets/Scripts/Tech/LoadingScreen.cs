using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadingScreen : MonoBehaviour
{
    [Tooltip("The path to the scene to load")]
    public string pathToScene;
    [Tooltip("The time to wait before loading the scene")]
    public float waitTime = 3.0f;

    void Start()
    {
        if (pathToScene == "" || pathToScene == null)
        {
            pathToScene = staticBackbone.sceneToLoad;
        }
        StartCoroutine(LoadScene());
    }

    void Update()
    {
        
    }

    IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(waitTime);

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(pathToScene);

        staticBackbone.sceneToLoad = null;

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}