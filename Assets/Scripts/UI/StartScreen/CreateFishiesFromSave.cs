using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class CreateFishiesFromSave : MonoBehaviour
{
    public GameObject[] fishies;
    public int maxFishies = 10;
    public Vector2 spawnRangeX = new Vector2(-10, 10);
    public Vector2 spawnRangeY = new Vector2(-5, 5);

    private List<string> possibleFishies;
    private Dictionary<string, GameObject> fishieDict;

    void Start()
    {
        InitializeFishieDict();
        GetBoolsAsString();
        InstantiateFishies();
    }

    void InitializeFishieDict()
    {
        fishieDict = new Dictionary<string, GameObject>();

        foreach (var fish in fishies)
        {
            fishieDict[fish.name] = fish;
        }
    }

    void InstantiateFishies()
    {
        if (possibleFishies.Count == 0 || possibleFishies == null || fishies.Length == 0 || fishies == null)
        {
            Debug.Log("No fishies to instantiate");
            return;
        }

        maxFishies = Mathf.Min(maxFishies, possibleFishies.Count);

        for (int i = 0; i < maxFishies; i++)
        {
            int randomIndex = Random.Range(0, possibleFishies.Count);
            string fishieName = possibleFishies[randomIndex];
            possibleFishies.RemoveAt(randomIndex);

            if (fishieDict.TryGetValue(fishieName, out GameObject selectedFishie))
            {
                Instantiate(selectedFishie,
                    new Vector3(Random.Range(spawnRangeX.x, spawnRangeX.y), Random.Range(spawnRangeY.x, spawnRangeY.y), 0),
                    Quaternion.identity);
            }
            else
            {
                Debug.Log($"No prefab found for: {fishieName}");
            }
        }
    }

    void GetBoolsAsString()
    {
        possibleFishies = new List<string>();

        string[] allFishNames = {
            "caveHermitCrab", "cavePurpleSquid", "caveCrystalSlug",
            "canalCrocBaby", "canalNemoBag", "canalTeethFish",
            "lavaCerberus", "lavaFishboneFire", "lavaBlackHole",
            "seaTurtleLifering", "seaWaterBall", "seaAlgaeEel", "seaKoinobori",
            "retroPcFish", "retroGameBoy", "retroTetris", "retroTamagotchi",
            "magicForrestWoodBlank", "magicForrestBullfrog", "magicForrestBlobfish",
            "cloudLakeMola", "cloudLakeCloud", "cloudLakeBaloony", "cloudLakeShootingStar",
            "catFish", "FishStick", "Chtulhu", "rubberDuckie"
        };

        foreach (string fish in allFishNames)
        {
            if (SaveLoad.GetBool(fish))
            {
                possibleFishies.Add(fish);
            }
        }
    }
}