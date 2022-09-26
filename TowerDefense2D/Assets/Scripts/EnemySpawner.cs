using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject enemePrefab;

    [SerializeField]
    private float enemyInterval = 5f;

    //The numebr of enemies spawning in a wave
    //private GameObject Enemy = 0;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnEnemy(enemyInterval, enemePrefab));
    }

    private IEnumerator spawnEnemy(float Interval, GameObject Enemy)
    {
        yield return new WaitForSeconds(Interval);
        GameObject newEnemy = Instantiate(Enemy, new Vector3(Random.Range(-5f, 5f), Random.Range(-6f, 6f), 0), Quaternion.identity);
        StartCoroutine(spawnEnemy(Interval, Enemy));
    }
}
