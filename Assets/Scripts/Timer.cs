using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public int time;
    public TMP_Text timerText;
    public TMP_Text finalTimeText;
    public TMP_Text hpText;
    private float elapsedTime = 0f;
    private bool isFinished = false;
    private float finalHealth;
    GameObject player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.Find("Player") != null)
        {
            elapsedTime += Time.deltaTime;

            int minutes = (int)elapsedTime / 60;
            int seconds = (int)elapsedTime % 60;
            int milliseconds = (int)(elapsedTime * 1000) % 1000;

            timerText.text = string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliseconds);

            int health = (int)(player.GetComponent<SpriteRenderer>().color.g * 10);
            hpText.text = health.ToString() + "hp";
            
            if (elapsedTime >= time)
            {
                finalHealth = player.GetComponent<SpriteRenderer>().color.g;
                Destroy(player);
            }
        }
        else
        {
            if (!isFinished)
            {
                int score = (int)(elapsedTime * elapsedTime);
                if (elapsedTime < time)
                {
                    finalTimeText.text = "Game Over!\n" + timerText.text + "\nScore: " + score.ToString();
                    timerText.text = "";
                }
                else
                {
                    int health = (int)(finalHealth * 10);
                    if (health > 0)
                    {
                        score *= health * health;
                    }
                    else
                    {
                        score *= 2;
                    }
                    finalTimeText.text = "You Win!\n" + health.ToString() + "hp / 10hp\nScore: " + score.ToString();
                }
                isFinished = true;
            }
        }
    }
}
