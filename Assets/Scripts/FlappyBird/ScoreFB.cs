using UnityEngine;
using TMPro;

public class ScoreFB : MonoBehaviour
{
    public int score = 0;
    public bool gameOver = false;
    public TMP_Text scoreText;
    public TMP_Text timerText;
    public TMP_Text gameOverText;
    private float elapsedTime = 0f;
    private int minutes = 0;
    private int seconds = 0;
    private int milliseconds = 0;

    public float speed = 5f;
    public int difficulty2 = 60;
    public float maxSpeedModifier = 3f;
    public int stepSize = 2;
    public float speedIncrease = 0.03f;
    private bool increaseSpeed = true;
    private float gravity;
    public GameObject player;
    private Rigidbody2D playerBody;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerBody = player.GetComponent<Rigidbody2D>();
        gravity = playerBody.gravityScale;
    }

    // Update is called once per frame
    void Update()
    {
        // TODO
        // the scoring system and timer only works with no replays
        // if replays are required, this script needs to be modified!!!
        // for replays, it should be prefered to load another scene and reload this scene after
        if (!gameOver)
        {
            scoreText.text = score.ToString() + "pts";

            elapsedTime += Time.deltaTime;

            minutes = (int)elapsedTime / 60;
            seconds = (int)elapsedTime % 60;
            milliseconds = (int)(elapsedTime * 1000) % 1000;

            timerText.text = string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliseconds) + "s";
            gameOverText.text = "";
        }
        else
        {
            gameOverText.text = "Game Over!\nScore: " + score + "pts\nTime: " + string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliseconds) + "s\npress 'e' to continue";
            scoreText.text = "";
            timerText.text = "";
        }

        if (score >= difficulty2)
        {
            if (score % stepSize == 0 && speed < speed * maxSpeedModifier && increaseSpeed)
            {
                speed += speedIncrease;
                playerBody.gravityScale = gravity * (speed / 5f);
                Debug.Log("Speed: " + speed);
                increaseSpeed = false;
            }
            else if (!increaseSpeed && score % stepSize != 0)
            {
                increaseSpeed = true;
            }
        }
    }
}
