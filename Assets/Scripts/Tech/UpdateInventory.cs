using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine.Rendering;

public class UpdateInventory : MonoBehaviour
{
    public float waitBeforeAnimation = 0.5f;
    public GameObject circleAnim;
    public GameObject[] fishPrefab;

    public enum possibleNames
    {
        caveHermitCrab,
        cavePurpleSquid,
        caveCrystalSlug,
        canalCrocBaby,
        canalNemoBag,
        canalTeethFish,
        lavaCerberus,
        lavaFishboneFire,
        lavaBlackHole,
        seaTurtleLifering,
        seaWaterBall,
        seaAlgaeEel,
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
        catFish,
        FishStick,
        Chtulhu,
        rubberDuckie
    }
    public possibleNames[] nameOfFish;
    private List<string> fishName = new List<string>();
    public float positionAfterLoad = 0f;
    private GameObject player;

    void Start()
    {
        foreach (possibleNames name in nameOfFish)
        {
            Debug.Log(name);
            // Debug.Log(name.ToString());
            // Debug.Log(fishName);
            fishName.Add(name.ToString());
            // Debug.Log(fishName);
        }

        player = GameObject.Find("Player");

        if (staticBackbone.playedMiniGame)
        {
            Transform playerTransform = player.transform;
            playerTransform.position = new Vector3(positionAfterLoad, playerTransform.position.y, playerTransform.position.z);
            
            if (staticBackbone.gotFish)
            {
                StartCoroutine(GotFish());
            }
            else if (!staticBackbone.gotFish)
            {
                StartCoroutine(NoFish());
            }
        }

        staticBackbone.playedMiniGame = false;
        staticBackbone.gotFish = false;
    }

    IEnumerator GotFish()
    {
        string useThisFish = fishName[Random.Range(0, fishName.Count)];
        GameObject useThisPrefab = null;
        int safetyCounter = 0;
        foreach (GameObject possiblePrefab in fishPrefab)
        {
            Debug.Log(possiblePrefab.name);
            if (possiblePrefab.name == useThisFish)
            {
                useThisPrefab = possiblePrefab;
                break;
            }
            else if (safetyCounter < fishPrefab.Length)
            {
                safetyCounter++;
            }
            else
            {
                Debug.LogWarning("No matching fish found for " + useThisFish);
                yield break;
            }
        }
        player.GetComponent<PlayerMovement>().enabled = false;
        yield return new WaitForSeconds(waitBeforeAnimation);
        circleAnim.SetActive(true);
        Animator playerAnim = player.transform.Find("MC-Idle-FINAL").gameObject.GetComponent<Animator>();
        playerAnim.SetBool("Climb", false);
        playerAnim.SetBool("Fish", false);
        playerAnim.SetBool("Idle", false);
        playerAnim.SetBool("Walk", false);
        playerAnim.SetBool("Win", true);
        GameObject fish = Instantiate(useThisPrefab, circleAnim.transform.position, Quaternion.identity);
        fish.SetActive(true);
        fish.GetComponent<FishiesSwim>().enabled = false;
        fish.name = "fishAnim";
        fish.GetComponent<SortingGroup>().sortingOrder = circleAnim.transform.Find("Layer 5").gameObject.GetComponent<SpriteRenderer>().sortingOrder + 1;
        fish.transform.localScale = new Vector3(2f, 2f, 2f);

        SetBoolByName(useThisFish);

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