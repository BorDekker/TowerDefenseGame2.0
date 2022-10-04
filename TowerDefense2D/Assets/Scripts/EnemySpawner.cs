using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab;

    [SerializeField]
    private float enemyInterval = 5f;


    [SerializeField]
    private GameObject heavyEnemyPrefab;

    [SerializeField]
    private float heavyEnemyInterval = 10f;


    [SerializeField]
    private GameObject smallEnemyPrefab;

    [SerializeField]
    private float smallEnemyInterval = 20f;

    //The numebr of enemies spawning in a wave
    //private GameObject EnemyNumbers = 0;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnEnemy(enemyInterval, enemyPrefab));

        StartCoroutine(spawnEnemy(heavyEnemyInterval, heavyEnemyPrefab));

        StartCoroutine(spawnEnemy(smallEnemyInterval, smallEnemyPrefab));
    }

    private IEnumerator spawnEnemy(float Interval, GameObject Enemy)
    {
        yield return new WaitForSeconds(Interval);
        GameObject newEnemy = Instantiate(Enemy, new Vector3(Random.Range(-5f, 5f), Random.Range(-6f, 6f), 0), Quaternion.identity);
        StartCoroutine(spawnEnemy(Interval, Enemy));
    }
}
