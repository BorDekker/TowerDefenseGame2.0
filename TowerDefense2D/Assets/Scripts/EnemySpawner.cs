using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class EnemySpawner : MonoBehaviour
{
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

    public int waveCount;

    public int waveLenght = 30;

    public int delayToNextWave = 20;

    //The numebr of enemies spawning in a wave
    //private GameObject EnemyNumbers = 0;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnEnemy(enemyInterval, enemyPrefab));

        StartCoroutine(spawnEnemy(heavyEnemyInterval, heavyEnemyPrefab));

        StartCoroutine(spawnEnemy(smallEnemyInterval, smallEnemyPrefab));
    }

    public IEnumerator spawnEnemy(float Interval, GameObject Enemy)
    {
        if(delayToNextWave <= 0)
        {
            yield return new WaitForSeconds(Interval);
            GameObject newEnemy = Instantiate(Enemy, new Vector3(Random.Range(-5f, 5f), Random.Range(-6f, 6f), 0), Quaternion.identity);
            newEnemy.GetComponent<EnemyBehaviour>().Waypoints = wayPoints;
            StartCoroutine(spawnEnemy(Interval, Enemy));
        }
    }

    private void Update()
    {
        if (GameObject.Find("HealthBar").GetComponent<Slider>().value <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            Debug.Log("You Died");
        }
    }
}
