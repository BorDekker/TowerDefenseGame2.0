using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class EnemySpawner : MonoBehaviour
{
    //Wave waves;s

    public GameObject[] wayPoints;

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
        //delayToNextWave = delayBetweenWaves;
        
                StartCoroutine(spawnEnemy(enemyInterval, enemyPrefab));

                StartCoroutine(spawnEnemy(heavyEnemyInterval, heavyEnemyPrefab));

                StartCoroutine(spawnEnemy(smallEnemyInterval, smallEnemyPrefab));
        
    }

    public IEnumerator spawnEnemy(float Interval, GameObject Enemy)
    {
        yield return new WaitForSeconds(Interval);
        GameObject newEnemy = Instantiate(Enemy, new Vector3(Random.Range(-5f, 5f), Random.Range(-6f, 6f), 0), Quaternion.identity);
        newEnemy.GetComponent<EnemyBehaviour>().Waypoints = wayPoints;
        StartCoroutine(spawnEnemy(Interval, Enemy));
    }

    private void Update()
    {
        /*
        if (delayToNextWave <= 0)
        {
            SpawnWave();
            delayToNextWave = 200;
        }
        delayToNextWave -= Time.deltaTime;
        */

        if (GameObject.Find("HealthBar").GetComponent<Slider>().value <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            Debug.Log("You Died");
        }
    }
}
/*
    public void SpawnWave()
    {
        StartCoroutine(spawnEnemy(enemyInterval, enemyPrefab));
        StartCoroutine(spawnEnemy(heavyEnemyInterval, heavyEnemyPrefab));
        StartCoroutine(spawnEnemy(smallEnemyInterval, smallEnemyPrefab));
        waves = new Wave();
        Debug.Log(waves.enemy.name);
        Debug.Log("StartWave");
    }
}
    */
