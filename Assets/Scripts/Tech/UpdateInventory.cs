using UnityEngine;
using System.Collections;
using UnityEngine.Rendering;

public class UpdateInventory : MonoBehaviour
{
    public float waitBeforeAnimation = 0.5f;
    public GameObject circleAnim;
    public GameObject fishPrefab;
    public string fishName;

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
        GameObject.Find("Player").GetComponent<PlayerMovement>().enabled = false;
        yield return new WaitForSeconds(waitBeforeAnimation);
        circleAnim.SetActive(true);
        GameObject fish = Instantiate(fishPrefab, circleAnim.transform.position, Quaternion.identity);
        fish.SetActive(true);
        fish.name = "fishAnim";
        fish.GetComponent<SortingGroup>().sortingOrder = circleAnim.transform.Find("Layer 5").gameObject.GetComponent<SpriteRenderer>().sortingOrder + 1;
        fish.transform.localScale = new Vector3(2f, 2f, 2f);
        // TODO
        // Add the correct fish to the inventory
        // check the fishName and find the corresponding bool in the Inventory.cs
        // Optionally, auto save the game
    }

    IEnumerator NoFish()
    {
        yield return new WaitForSeconds(waitBeforeAnimation);
        Debug.Log("No Fish");
    }
}