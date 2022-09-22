using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] Transform[] Waypoints;

    [SerializeField] float MoveSpeed = 2f;

    int WayPointIndex = 0;

    void Start()
    {
        transform.position = Waypoints[WayPointIndex].transform.position;
    }

    void Update()
    {
        Move();
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
            WayPointIndex = 0;
        }
    }
}
