using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] float Damage;

    public GameObject[] Waypoints;

    Slider HPbar;

    [SerializeField] float MoveSpeed = 2f;

    int WayPointIndex = 0;

    public int EnemyHealth;

    public int enemyWorth;

    public float EnemyLifeTime;

    float EnemyStartTime;

    public int maxHealth;

    void Start()
    {
        transform.position = Waypoints[WayPointIndex].transform.position;

        HPbar = GameObject.Find("HealthBar").GetComponent<Slider>();

        EnemyStartTime = Time.time;

        maxHealth = EnemyHealth;
    }

    void Update()
    {
        EnemyLifeTime = (Time.time - EnemyStartTime) * MoveSpeed;
        Move();
        if (EnemyHealth <= 0)
        {
            if(gameObject.name == "Boss(Clone)")
            {
                SceneManager.LoadScene(4);
            }
            GameObject.Find("Placement").GetComponent<TowerPlacement>().totalMoney += enemyWorth;
            Destroy(gameObject);
        }
    }

    void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, Waypoints[WayPointIndex].transform.position, MoveSpeed * Time.deltaTime);

        if (transform.position == Waypoints[WayPointIndex].transform.position)
        {
            WayPointIndex += 1;
        }

        if (WayPointIndex == Waypoints.Length)
        {
            HPbar.value -= Damage;
            WayPointIndex = 0;
            GameObject.Find("Placement").GetComponent<TowerPlacement>().totalMoney += enemyWorth;
            Destroy(gameObject);
            //Player HP naar beneden;
        }
    }
}
