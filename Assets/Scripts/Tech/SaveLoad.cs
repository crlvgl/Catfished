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
        SetBool("canalTeethFish", Inventory.canalTeethFish);
        SetBool("lavaCerberus", Inventory.lavaCerberus); // lava fish
        SetBool("lavaFishboneFire", Inventory.lavaFishboneFire);
        SetBool("lavaBlackHole", Inventory.lavaBlackHole);
        SetBool("seaTurtleLifering", Inventory.seaTurtleLifering); // sea fish
        SetBool("seaWaterBall", Inventory.seaWaterBall);
        SetBool("seaAlgaeEel", Inventory.seaAlgaeEel);
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
        SetBool("FishStick", Inventory.FishStick); // fish stick
        SetBool("Chtulhu", Inventory.Chtulhu); // chtulhu
        SetBool("rubberDuckie", Inventory.rubberDuckie); // rubber duckie

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
        Inventory.canalTeethFish = GetBool("canalTeethFish");
        Inventory.lavaCerberus = GetBool("lavaCerberus"); // lava fish
        Inventory.lavaFishboneFire = GetBool("lavaFishboneFire");
        Inventory.lavaBlackHole = GetBool("lavaBlackHole");
        Inventory.seaTurtleLifering = GetBool("seaTurtleLifering"); // sea fish
        Inventory.seaWaterBall = GetBool("seaWaterBall");
        Inventory.seaAlgaeEel = GetBool("seaAlgaeEel");
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
        Inventory.FishStick = GetBool("FishStick"); // fish stick
        Inventory.Chtulhu = GetBool("Chtulhu"); // chtulhu
        Inventory.rubberDuckie = GetBool("rubberDuckie"); // rubber duckie

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

        Debug.Log(@$"Loaded Inventory to
        caveHermitCrab: {Inventory.caveHermitCrab}
        cavePurpleSquid: {Inventory.cavePurpleSquid}
        caveCrystalSlug: {Inventory.caveCrystalSlug}
        canalCrocBaby: {Inventory.canalCrocBaby}
        canalNemoBag: {Inventory.canalNemoBag}
        canalTeethFish: {Inventory.canalTeethFish}
        lavaCerberus: {Inventory.lavaCerberus}
        lavaFishboneFire: {Inventory.lavaFishboneFire}
        lavaBlackHole: {Inventory.lavaBlackHole}
        seaTurtleLifering: {Inventory.seaTurtleLifering}
        seaWaterBall: {Inventory.seaWaterBall}
        seaAlgaeEel: {Inventory.seaAlgaeEel}
        seaKoinobori: {Inventory.seaKoinobori}
        retroPcFish: {Inventory.retroPcFish}
        retroGameBoy: {Inventory.retroGameBoy}
        retroTetris: {Inventory.retroTetris}
        retroTamagotchi: {Inventory.retroTamagotchi}
        magicForrestWoodBlank: {Inventory.magicForrestWoodBlank}
        magicForrestBullfrog: {Inventory.magicForrestBullfrog}
        magicForrestBlobfish: {Inventory.magicForrestBlobfish}
        cloudLakeMola: {Inventory.cloudLakeMola}
        cloudLakeCloud: {Inventory.cloudLakeCloud}
        cloudLakeBaloony: {Inventory.cloudLakeBaloony}
        cloudLakeShootingStar: {Inventory.cloudLakeShootingStar}
        catFish: {Inventory.catFish}
        FishStick: {Inventory.FishStick}
        Chtulhu: {Inventory.Chtulhu}
        rubberDuckie: {Inventory.rubberDuckie}");
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