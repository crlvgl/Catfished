using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ReturnToOverworldFB : MonoBehaviour
{
    public KeyCode returnKey = KeyCode.E;
    private ScoreFB scoreFB;
    public int requiredScore;

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
                staticBackbone.playedMiniGame = true;
                if (scoreFB.score >= requiredScore)
                {
                    staticBackbone.gotFish = true;
                }
                StartCoroutine(LoadOverworld());
            }
        }
    }

    IEnumerator LoadOverworld()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(staticBackbone.sceneToReturnTo);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}