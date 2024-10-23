using UnityEngine;
using System.Collections;

public class EnemyFireControl : MonoBehaviour
{
    GameObject[] enemies;
    int enemyAmount;
    public static int enemyFires = 1;
    public float minRechoise = 3f;
    public float maxRechoice = 8f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        enemyAmount = enemies.Length;

        if (enemyAmount > 0)
        {
            StartCoroutine(EnemyFire());
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator EnemyFire()
    {
        if (enemyAmount > 0)
        {
            yield return new WaitForSeconds(Random.Range(minRechoise, maxRechoice));
            enemyFires = Random.Range(1, enemyAmount);
            StartCoroutine(EnemyFire());
        }
    }
}
