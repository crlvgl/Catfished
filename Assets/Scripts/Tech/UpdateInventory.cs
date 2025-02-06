using UnityEngine;
using System.Collections;
using System.Reflection;
using UnityEngine.Rendering;

public class UpdateInventory : MonoBehaviour
{
    public float waitBeforeAnimation = 0.5f;
    public GameObject circleAnim;
    public GameObject fishPrefab;

    public enum possibleNames
    {
        caveHermitCrab,
        cavePurpleSquid,
        caveCrystalSlug,
        canalCrocBaby,
        canalNemoBag,
        canalRadioactiveFish,
        lavaCerberus,
        lavaFishStick,
        lavaFishboneFire,
        lavaAngyGray,
        seaTurtleLifering,
        seaWaterBall,
        seaAlgaeEel,
        seaSub,
        seaKoinobori,
        retroPcFish,
        retroGameBoy,
        retroTetris,
        retroTamagotchi,
        magicForrestWoodBlank,
        magicForrestBullfrog,
        magicForrestBlobfish,
        cloudLakeMola,
        cloudLakeCloud,
        cloudLakeBaloony,
        cloudLakeShootingStar,
        catFish
    }
    public possibleNames nameOfFish;
    private string fishName;

    void Start()
    {
        fishName = nameOfFish.ToString();
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

        SetBoolByName(fishName);

        Debug.Log("Saving game...");
        SaveLoad.SaveGame();
    }

    void SetBoolByName(string name)
    {
        FieldInfo field = typeof(Inventory).GetField(name, BindingFlags.Public | BindingFlags.Static);

        if (field != null && field.FieldType == typeof(bool))
        {
            field.SetValue(null, true);
            Debug.Log(name + "set to true in inventory");
        }
        else
        {
            Debug.LogWarning($"No matching boolean found for {name} in Inventory");
        }
    }

    IEnumerator NoFish()
    {
        yield return new WaitForSeconds(waitBeforeAnimation);
        Debug.Log("No Fish");

        Debug.Log("Saving game...");
        SaveLoad.SaveGame();
    }
}