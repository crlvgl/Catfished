using UnityEngine;
using System.Collections;

public class UpdateInventory : MonoBehaviour
{
    public float waitBeforeAnimation = 0.5f;
    public GameObject circleAnim;
    public string pathToFishSprite;

    void Start()
    {
        if (staticBackbone.playedMiniGame && staticBackbone.gotFish)
        {
            StartCoroutine(GotFish());
        }
        else if (staticBackbone.playedMiniGame && !staticBackbone.gotFish)
        {
            StartCoroutine(NoFish());
        }

        staticBackbone.playedMiniGame = false;
        staticBackbone.gotFish = false;
    }

    IEnumerator GotFish()
    {
        yield return new WaitForSeconds(waitBeforeAnimation);
        circleAnim.SetActive(true);
        GameObject fish = new GameObject("FishAnim");
        fish.SetActive(true);
        fish.AddComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(pathToFishSprite);
        fish.GetComponent<SpriteRenderer>().sortingOrder = circleAnim.GetComponent<SpriteRenderer>().sortingOrder + 1;
        fish.transform.position = circleAnim.transform.position;
    }

    IEnumerator NoFish()
    {
        yield return new WaitForSeconds(waitBeforeAnimation);
        Debug.Log("No Fish");
    }
}