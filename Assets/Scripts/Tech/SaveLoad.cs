using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class SaveLoad : MonoBehaviour
{
    public static SaveLoad _instance;

    public static void SaveGame(bool savePlayerPosition = true)
    {
        // player position
        if (savePlayerPosition)
        {
            if (GameObject.Find("Player") != null)
            {
                PlayerPrefs.SetString("currentScene", SceneManager.GetActiveScene().name);
                PlayerPrefs.SetFloat("playerPositionX", GameObject.Find("Player").transform.position.x);
            }
        }

        // fishies
        SetBool("caveHermitCrab", Inventory.caveHermitCrab); // cave fish
        SetBool("cavePurpleSquid", Inventory.cavePurpleSquid);
        SetBool("caveCrystalSlug", Inventory.caveCrystalSlug);
        SetBool("canalCrocBaby", Inventory.canalCrocBaby); // canal fish
        SetBool("canalNemoBag", Inventory.canalNemoBag);
        SetBool("canalRadioactiveFish", Inventory.canalRadioactiveFish);
        SetBool("lavaCerberus", Inventory.lavaCerberus); // lava fish
        SetBool("lavaFishStick", Inventory.lavaFishStick);
        SetBool("lavaFishboneFire", Inventory.lavaFishboneFire);
        SetBool("lavaAngyGray", Inventory.lavaAngyGray);
        SetBool("seaTurtleLifering", Inventory.seaTurtleLifering); // sea fish
        SetBool("seaWaterBall", Inventory.seaWaterBall);
        SetBool("seaAlgaeEel", Inventory.seaAlgaeEel);
        SetBool("seaSub", Inventory.seaSub);
        SetBool("seaKoinobori", Inventory.seaKoinobori);
        SetBool("retroPcFish", Inventory.retroPcFish); // retro fish
        SetBool("retroGameBoy", Inventory.retroGameBoy);
        SetBool("retroTetris", Inventory.retroTetris);
        SetBool("retroTamagotchi", Inventory.retroTamagotchi);
        SetBool("magicForrestWoodBlank", Inventory.magicForrestWoodBlank); // magic forrest fish
        SetBool("magicForrestBullfrog", Inventory.magicForrestBullfrog);
        SetBool("magicForrestBlobfish", Inventory.magicForrestBlobfish);
        SetBool("cloudLakeMola", Inventory.cloudLakeMola); // cloud lake fish
        SetBool("cloudLakeCloud", Inventory.cloudLakeCloud);
        SetBool("cloudLakeBaloony", Inventory.cloudLakeBaloony);
        SetBool("cloudLakeShootingStar", Inventory.cloudLakeShootingStar);
        SetBool("catFish", Inventory.catFish); // cat fish

        Debug.Log("Game saved");
    }

    public static void LoadGame()
    {
        // fishies
        Inventory.caveHermitCrab = GetBool("caveHermitCrab"); // cave fish
        Inventory.cavePurpleSquid = GetBool("cavePurpleSquid");
        Inventory.caveCrystalSlug = GetBool("caveCrystalSlug");
        Inventory.canalCrocBaby = GetBool("canalCrocBaby"); // canal fish
        Inventory.canalNemoBag = GetBool("canalNemoBag");
        Inventory.canalRadioactiveFish = GetBool("canalRadioactiveFish");
        Inventory.lavaCerberus = GetBool("lavaCerberus"); // lava fish
        Inventory.lavaFishStick = GetBool("lavaFishStick");
        Inventory.lavaFishboneFire = GetBool("lavaFishboneFire");
        Inventory.lavaAngyGray = GetBool("lavaAngyGray");
        Inventory.seaTurtleLifering = GetBool("seaTurtleLifering"); // sea fish
        Inventory.seaWaterBall = GetBool("seaWaterBall");
        Inventory.seaAlgaeEel = GetBool("seaAlgaeEel");
        Inventory.seaSub = GetBool("seaSub");
        Inventory.seaKoinobori = GetBool("seaKoinobori");
        Inventory.retroPcFish = GetBool("retroPcFish"); // retro fish
        Inventory.retroGameBoy = GetBool("retroGameBoy");
        Inventory.retroTetris = GetBool("retroTetris");
        Inventory.retroTamagotchi = GetBool("retroTamagotchi");
        Inventory.magicForrestWoodBlank = GetBool("magicForrestWoodBlank"); // magic forrest fish
        Inventory.magicForrestBullfrog = GetBool("magicForrestBullfrog");
        Inventory.magicForrestBlobfish = GetBool("magicForrestBlobfish");
        Inventory.cloudLakeMola = GetBool("cloudLakeMola"); // cloud lake fish
        Inventory.cloudLakeCloud = GetBool("cloudLakeCloud");
        Inventory.cloudLakeBaloony = GetBool("cloudLakeBaloony");
        Inventory.cloudLakeShootingStar = GetBool("cloudLakeShootingStar");
        Inventory.catFish = GetBool("catFish"); // cat fish

        // player position
        staticBackbone.sceneToLoad = PlayerPrefs.GetString("currentScene");
        staticBackbone.playerPositionX = PlayerPrefs.GetFloat("playerPositionX");
        staticBackbone.moveCharacterNow = true;
        if (_instance != null)
        {
            _instance.StartCoroutine(_instance.LoadSceneAsync());
        }
        else
        {
            Debug.Log("SaveLoad instance is missing");
        }

        Debug.Log("Game loading...");
    }

    public static void SetBool(string key, bool value)
    {
        PlayerPrefs.SetInt(key, value ? 1 : 0);
    }

    public static bool GetBool(string key, bool defaultValue = false)
    {
        return PlayerPrefs.GetInt(key, defaultValue ? 1 : 0) == 1;
    }

    IEnumerator LoadSceneAsync()
    {
        if (!Application.isPlaying)
        {
            Debug.Log("Attempting to load scene while not in play mode");
            yield break;
        }

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Assets/Scenes/LoadingScreen.unity");

        if (asyncLoad == null)
        {
            Debug.Log("asyncLoad is null");
            yield break;
        }

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }

    private void OnApplicationQuit()
    {
        _instance = null;
    }
}