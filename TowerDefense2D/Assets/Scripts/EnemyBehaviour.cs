using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] Transform[] Waypoints;

    [SerializeField] float MoveSpeed = 2f;

    int WayPointIndex = 0;

    public int EnemyHealth;

    public float EnemyLifeTime;
    float EnemyStartTime;

    void Start()
    {
        EnemyHealth = 100;
        transform.position = Waypoints[WayPointIndex].transform.position;

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
            //WayPointIndex = 0;
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int SomeDamage)
    {
        EnemyHealth -= SomeDamage;
    }
}
