using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine.Rendering;

public class GetFishOnce : MonoBehaviour
{
    public GameObject fishPrefab;
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
    public possibleNames nameOfFish;
    private string fishName;

    public float waitBeforeAnimation = 0.5f;
    public GameObject circleAnim;
    public KeyCode actionKey = KeyCode.Space;

    private bool canBeActive = false;
    public bool showIndicator = false;
    public GameObject searchIndicator;
    public float fadeModifier = 1f;

    void Start()
    {
        fishName = nameOfFish.ToString();

        if (GetBoolByName(fishName) || SaveLoad.GetBool(fishName))
        {
            Destroy(circleAnim);
            Destroy(this.gameObject);
        }
    }

    void Update()
    {
        if (canBeActive && Input.GetKeyDown(actionKey))
        {
            StartCoroutine(GetFish());
        }
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.name);
        if (other.name == "Player")
        {
            Debug.Log("Player entered trigger");
            if (showIndicator)
            {
                StartCoroutine(ModifyIndicator(true));
            }
            canBeActive = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            Debug.Log("Player left trigger");
            if (showIndicator)
            {
                StartCoroutine(ModifyIndicator(false));
            }
            canBeActive = false;
        }
    }

    IEnumerator GetFish()
    {
        GameObject.Find("Player").GetComponent<PlayerMovement>().enabled = false;
        yield return new WaitForSeconds(waitBeforeAnimation);
        circleAnim.SetActive(true);
        GameObject fish = Instantiate(fishPrefab, circleAnim.transform.position, Quaternion.identity);
        fish.SetActive(true);
        fish.GetComponent<FishiesSwim>().enabled = false;
        fish.name = "fishAnim";
        fish.GetComponent<SortingGroup>().sortingOrder = circleAnim.transform.Find("Layer 5").gameObject.GetComponent<SpriteRenderer>().sortingOrder + 1;
        fish.transform.localScale = new Vector3(2f, 2f, 2f);

        SetBoolByName(fishName);

        Debug.Log("Saving game...");
        SaveLoad.SaveGame();

        Destroy(this.gameObject);
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

    bool GetBoolByName(string name)
    {
        FieldInfo field = typeof(Inventory).GetField(name, BindingFlags.Public | BindingFlags.Static);

        if (field != null && field.FieldType == typeof(bool))
        {
            return (bool)field.GetValue(null);
        }
        else
        {
            Debug.LogWarning($"No matching boolean found for {name} in Inventory");
            return false; // Default return value if the field is not found
        }
    }

    IEnumerator ModifyIndicator(bool fadeIn)
    {
        if (fadeIn)
        {
            searchIndicator.SetActive(true);
        }

        SpriteRenderer sr = searchIndicator.GetComponent<SpriteRenderer>();
        while (fadeIn ? sr.color.a < 1 : sr.color.a > 0)
        {
            sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, Mathf.Clamp01(sr.color.a + (fadeIn ? Time.deltaTime : -Time.deltaTime) * fadeModifier));
            yield return null;
        }

        if (!fadeIn)
        {
            searchIndicator.SetActive(false);
        }
    }
}