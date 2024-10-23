using UnityEngine;
using TMPro;

public class TimerScore : MonoBehaviour
{
    public TMP_Text timerText;
    public TMP_Text scoreText;
    public TMP_Text gameOverText;
    private float elapsedTime = 0f;
    public static int score = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameOverText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerHealth.health > 0)
        {
            elapsedTime += Time.deltaTime;

            int minutes = (int)elapsedTime / 60;
            int seconds = (int)elapsedTime % 60;
            int milliseconds = (int)(elapsedTime * 1000) % 1000;

            timerText.text = string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliseconds);
            
            scoreText.text = score.ToString() + "pts";
        }
        else if (PlayerHealth.health <= 0)
        {
            gameOverText.text = "Game Over\nFinal Score: " + score + "pts\nFinal Time: " + string.Format("{0:00}:{1:00}:{2:000}", (int)elapsedTime / 60, (int)elapsedTime % 60, (int)(elapsedTime * 1000) % 1000);
            timerText.text = "";
            scoreText.text = "";
        }

    }
}
