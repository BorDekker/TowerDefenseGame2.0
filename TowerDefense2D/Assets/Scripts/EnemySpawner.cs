using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class EnemySpawner : MonoBehaviour
{
    public GameObject[] wayPoints;

    [SerializeField]
    private GameObject enemyPrefab;

    [SerializeField]
    private float enemyInterval;

    [SerializeField]
    private GameObject heavyEnemyPrefab;

    [SerializeField]
    private float heavyEnemyInterval;

    [SerializeField]
    private GameObject smallEnemyPrefab;

    [SerializeField]
    private float smallEnemyInterval;

    [SerializeField]
    private GameObject bossPrefab;

    public int waveCount;

    [SerializeField]
    TMP_Text WaveCounter;

    public float waveLenght;

    public bool waveBusy;

    public float delayToNextWave;

    public bool wavePause;

    public bool bossCanSpawn = true;

    [SerializeField]
    TMP_Text WaveTimer;

    [SerializeField]
    TMP_Text WaveDuration;

    IEnumerator myCoroutineTDE;

    IEnumerator myCoroutineTDHE;

    IEnumerator myCoroutineTDSE;

    //The numebr of enemies spawning in a wave
    //private GameObject EnemyNumbers = 0;

    // Start is called before the first frame update
    void Start()
    {
        wavePause = true;
        waveBusy = false;

        myCoroutineTDE = spawnEnemy(enemyInterval, enemyPrefab);

        myCoroutineTDHE = spawnEnemy(heavyEnemyInterval, heavyEnemyPrefab);

        myCoroutineTDSE = spawnEnemy(smallEnemyInterval, smallEnemyPrefab);

        //StartCoroutine(spawnEnemy(enemyInterval, enemyPrefab));

        //StartCoroutine(spawnEnemy(heavyEnemyInterval, heavyEnemyPrefab));

        //StartCoroutine(spawnEnemy(smallEnemyInterval, smallEnemyPrefab));
    }

    public IEnumerator spawnEnemy(float Interval, GameObject Enemy)
    {
        yield return new WaitForSeconds(Interval);
        if(waveBusy)
        {
            GameObject newEnemy = Instantiate(Enemy, new Vector3(Random.Range(-5f, 5f), Random.Range(-6f, 6f), 0), Quaternion.identity);
            newEnemy.GetComponent<EnemyBehaviour>().Waypoints = wayPoints;
        }
        StartCoroutine(spawnEnemy(Interval, Enemy));
    }

    private void Update()
    {
        if (wavePause)
        {
            if (delayToNextWave > 0)
            {
                delayToNextWave -= Time.deltaTime;
                UpdateTime(delayToNextWave);
            }
            else
            {
                Debug.Log("Next Wave Begins");
                delayToNextWave = 0;
                wavePause = false;
                waveBusy = true;

                StartCoroutine(myCoroutineTDE);

                StartCoroutine(myCoroutineTDHE);

                StartCoroutine(myCoroutineTDSE);

                waveCount++;
                
                waveLenght += 10;
            }
        }

        if (waveBusy)
        {
            if (waveLenght > 0)
            {
                waveLenght -= Time.deltaTime;
                WaveOngoing(waveLenght);
            }
            else
            {
                Debug.Log("Pause between waves");
                waveLenght = 0;
                wavePause = true;
                waveBusy = false;

                if(wavePause == true)
                {
                    StopCoroutine(myCoroutineTDE);

                    StopCoroutine(myCoroutineTDHE);

                    StopCoroutine(myCoroutineTDSE);
                }
               
                delayToNextWave += 10;
            }
        }

        if(waveCount == 2 && bossCanSpawn == true)
        {
            GameObject newEnemy = Instantiate(bossPrefab);
            newEnemy.GetComponent<EnemyBehaviour>().Waypoints = wayPoints;
            bossCanSpawn = false;
        }

        if (GameObject.Find("HealthBar").GetComponent<Slider>().value <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            Debug.Log("You Died");
        }
    }
    void UpdateTime(float currentTime)
    {
        currentTime += 1;

        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);

        WaveTimer.text = string.Format("Next Wave {00}:{1:00}", minutes, seconds);
    }

    void WaveOngoing(float CurrentTime)
    {
        CurrentTime += 1;

        float minutes = Mathf.FloorToInt(CurrentTime / 60);
        float seconds = Mathf.FloorToInt(CurrentTime % 60);

        WaveDuration.text = string.Format("Wave Lenght {00}:{1:00}", minutes, seconds);
    }
}