using UnityEngine;
using System.Collections;

public class HeartPop : MonoBehaviour
{
    public GameObject heart;
    private Animator heartAnim;
    // public float heartPopTime = 0.94f;
    public GameObject player;

    private bool canPlay = true;
    private bool isPlaying = false;

    void Start()
    {
        if (player == null)
        {
            player = GameObject.Find("Player");
        }
        if (heart == null)
        {
            heart = GameObject.Find("Heart-Reaction");
        }
        heartAnim = heart.GetComponent<Animator>();
        heart.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player" && canPlay && !isPlaying)
        {
            canPlay = false;
            StartCoroutine(HeartPopTime());
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            canPlay = true;
        }
    }

    IEnumerator HeartPopTime()
    {
        isPlaying = true;
        heart.SetActive(true);
        yield return new WaitForSeconds(heartAnim.GetCurrentAnimatorStateInfo(0).length);
        heart.SetActive(false);
        isPlaying = false;
    }
}