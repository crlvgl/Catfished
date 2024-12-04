using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManager;

public class GameOverScreen : MonoBehaviour
{
    public void Setup(int score) {  
        gameObject.SetActive(true);
        pointsText.text = score.ToString() + " POINTS";
    }

    public void RestartButton() {
        SceneManager.LoadScene("Game");
    }

    public void ExitButton() {
        SceneManager.LoadScene("MainMenu");
    }
}
