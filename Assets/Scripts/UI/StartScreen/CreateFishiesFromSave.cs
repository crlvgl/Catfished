using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class CreateFishiesFromSave : MonoBehaviour
{
    public GameObject[] fishies;
    public int maxFishies = 10;
    public Vector2 spawnRangeX = new Vector2(-10, 10);
    public Vector2 spawnRangeY = new Vector2(-5, 5);

    private string[] possibleFishies;
    private List<string> fishiesList = new List<string>();

    void Start()
    {
        InstantiateFishies();
    }

    void Update()
    {

    }

    void InstantiateFishies()
    {
        GetBoolsAsString();

        if (possibleFishies.Length == 0 || possibleFishies == null || fishies.Length == 0 || fishies == null)
        {
            Debug.Log("No fishies to instantiate");
            return;
        }

        if (maxFishies > possibleFishies.Length)
        {
            maxFishies = possibleFishies.Length;
        }

        for (int i = 0; i < maxFishies; i++)
        {
            string fishie = possibleFishies[Random.Range(0, possibleFishies.Length)];
            possibleFishies = possibleFishies.Where(val => val != fishie).ToArray();

            GameObject selectedFishie = System.Array.Find(fishies, fish => fish.name == fishie);

            if (selectedFishie != null)
            {
                GameObject fish = Instantiate(selectedFishie, new Vector3(Random.Range(spawnRangeX.x, spawnRangeX.y), Random.Range(spawnRangeY.x, spawnRangeY.y), 0), Quaternion.identity);
            }
            else
            {
                Debug.Log($"No prefab with name {fishie} found in Prefab List");
            }
        }
    }

    void GetBoolsAsString()
    {
        if (SaveLoad.GetBool("caveHermitCrab"))
        {
            fishiesList.Add("caveHermitCrab");
        }
        if (SaveLoad.GetBool("cavePurpleSquid"))
        {
            fishiesList.Add("cavePurpleSquid");
        }
        if (SaveLoad.GetBool("caveCrystalSlug"))
        {
            fishiesList.Add("caveCrystalSlug");
        }
        if (SaveLoad.GetBool("canalCrocBaby"))
        {
            fishiesList.Add("canalCrocBaby");
        }
        if (SaveLoad.GetBool("canalNemoBag"))
        {
            fishiesList.Add("canalNemoBag");
        }
        if (SaveLoad.GetBool("canalRadioactiveFish"))
        {
            fishiesList.Add("canalRadioactiveFish");
        }
        if (SaveLoad.GetBool("lavaCerberus"))
        {
            fishiesList.Add("lavaCerberus");
        }
        if (SaveLoad.GetBool("lavaFishboneFire"))
        {
            fishiesList.Add("lavaFishboneFire");
        }
        if (SaveLoad.GetBool("lavaAngyGray"))
        {
            fishiesList.Add("lavaAngyGray");
        }
        if (SaveLoad.GetBool("seaTurtleLifering"))
        {
            fishiesList.Add("seaTurtleLifering");
        }
        if (SaveLoad.GetBool("seaWaterBall"))
        {
            fishiesList.Add("seaWaterBall");
        }
        if (SaveLoad.GetBool("seaAlgaeEel"))
        {
            fishiesList.Add("seaAlgaeEel");
        }
        if (SaveLoad.GetBool("seaSub"))
        {
            fishiesList.Add("seaSub");
        }
        if (SaveLoad.GetBool("seaKoinobori"))
        {
            fishiesList.Add("seaKoinobori");
        }
        if (SaveLoad.GetBool("retroPcFish"))
        {
            fishiesList.Add("retroPcFish");
        }
        if (SaveLoad.GetBool("retroGameBoy"))
        {
            fishiesList.Add("retroGameBoy");
        }
        if (SaveLoad.GetBool("retroTetris"))
        {
            fishiesList.Add("retroTetris");
        }
        if (SaveLoad.GetBool("retroTamagotchi"))
        {
            fishiesList.Add("retroTamagotchi");
        }
        if (SaveLoad.GetBool("magicForrestWoodBlank"))
        {
            fishiesList.Add("magicForrestWoodBlank");
        }
        if (SaveLoad.GetBool("magicForrestBullfrog"))
        {
            fishiesList.Add("magicForrestBullfrog");
        }
        if (SaveLoad.GetBool("magicForrestBlobfish"))
        {
            fishiesList.Add("magicForrestBlobfish");
        }
        if (SaveLoad.GetBool("cloudLakeMola"))
        {
            fishiesList.Add("cloudLakeMola");
        }
        if (SaveLoad.GetBool("cloudLakeCloud"))
        {
            fishiesList.Add("cloudLakeCloud");
        }
        if (SaveLoad.GetBool("cloudLakeBaloony"))
        {
            fishiesList.Add("cloudLakeBaloony");
        }
        if (SaveLoad.GetBool("cloudLakeShootingStar"))
        {
            fishiesList.Add("cloudLakeShootingStar");
        }
        if (SaveLoad.GetBool("catFish"))
        {
            fishiesList.Add("catFish");
        }
        if (SaveLoad.GetBool("FishStick"))
        {
            fishiesList.Add("FishStick");
        }

        possibleFishies = fishiesList.ToArray();
    }
}