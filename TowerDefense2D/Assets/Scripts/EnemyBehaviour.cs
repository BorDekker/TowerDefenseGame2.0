using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] float Damage;

    public GameObject[] Waypoints;

    Slider HPbar;

    [SerializeField] float MoveSpeed = 2f;

    int WayPointIndex = 0;

    public int EnemyHealth;

    //public int HP lose Player;

    public float EnemyLifeTime;
    float EnemyStartTime;

    void Start()
    {
        transform.position = Waypoints[WayPointIndex].transform.position;

        HPbar = GameObject.Find("HealthBar").GetComponent<Slider>();

        EnemyStartTime = Time.time;
    }

    void Update()
    {
        EnemyLifeTime = (Time.time - EnemyStartTime) * MoveSpeed;
        Move();
        if (EnemyHealth <= 0)
        {
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
            Destroy(gameObject);
            //HP naar beneden;
        }
    }
    /*
    public void TakeDamage(int SomeDamage)
    {
        EnemyHealth -= SomeDamage;
    }
    */
}
