using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ReturnToOverworldFB : MonoBehaviour
{
    public KeyCode returnKey = KeyCode.E;
    public string overworldScene = "Assets/Scenes/Overworld/ForrestTest.unity";
    public string loadingScreenScene = "Assets/Scenes/LoadingScreen.unity";

    void Update()
    {
        if (ScoreFB.gameOver)
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