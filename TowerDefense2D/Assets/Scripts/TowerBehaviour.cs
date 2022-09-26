using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBehaviour : MonoBehaviour
{
    public GameObject Enemy;

    public float Distance = 3.5f;

    public float Damage = 20;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision)
        {
            FindTarget();
            AttackTarget();
            //CheckEnemyIfOutRange();
        }
        else
        {
            //FindNextTarget();
        }
        Debug.Log("The code WORKS!!");
    }

    void FindTarget()
    {
        if(Enemy)
        {
            this.Distance = Vector3.Distance(Enemy.transform.position, transform.position);
            Debug.Log("Distance to enemy:" + Distance);

        }
        Debug.Log("Target Found");
    }

    void AttackTarget()
    {
        //if(Enemy.transform.position)
        {

        }
    }
}
