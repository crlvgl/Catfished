using UnityEngine;
using System;

public class VSPlayerHealthXp: MonoBehaviour
{
    public int health = 100;
    public int playerXp = 0;
    public int[] playerLevels = {0, 100, 200, 300, 400, 500, 600, 700, 800, 900, 1000};

    public delegate void PlayerDeathHandler();
    public static event PlayerDeathHandler OnPlayerDeath;

    void Start()
    {
        
    }

    void Update()
    {
        if (health <= 0)
        {
            Debug.Log("Player is dead");
            Die();
        }

        LevelUp();
    }

    int[] RemoveFirstElement(int[] array)
    {
        int[] newArray = new int[array.Length - 1];
        Array.Copy(array, 1, newArray, 0, array.Length - 1);
        return newArray;
    }

    void Die()
    {
        OnPlayerDeath?.Invoke(); // Notify all listeners that the player has died

        Destroy(this.gameObject);
    }

    void LevelUp()
    {
        if (playerLevels.Length == 0)
        {
            return;
        }
        else if (playerXp >= playerLevels[0])
        {
            Debug.Log("Player leveled up");
            playerLevels = RemoveFirstElement(playerLevels);
        }
    }
}