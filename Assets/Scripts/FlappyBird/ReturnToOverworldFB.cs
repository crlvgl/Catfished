using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ReturnToOverworldFB : MonoBehaviour
{
    public KeyCode returnKey = KeyCode.E;
    public string overworldScene = "Assets/Scenes/Overworld/ForrestTest.unity";
    public string loadingScreenScene = "Assets/Scenes/LoadingScreen.unity";
    private ScoreFB scoreFB;

    void Start()
    {
        scoreFB = GameObject.Find("Score").gameObject.GetComponent<ScoreFB>();
    }

    void Update()
    {
        if (scoreFB.gameOver)
        {
            if (Input.GetKeyDown(returnKey))
            {
                StartCoroutine(LoadOverworld());
            }
        }
    }

    IEnumerator LoadOverworld()
    {
        staticBackbone.sceneToLoad = overworldScene;

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(loadingScreenScene);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}