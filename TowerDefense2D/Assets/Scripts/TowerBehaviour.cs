using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBehaviour : MonoBehaviour
{
    public GameObject Enemy;
    public GameObject HeavyEnemy;
    public GameObject SmallEnemy;

    public List<GameObject> Enemies;
    GameObject TargetEnemy;

    public float Distance;

    public int Damage;

    [SerializeField]
    public float Reload;

    [SerializeField]
    public float ReloadingTime = 0.5f;

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
        //Debug.Log("The code WORKS!!");
    }

    private void Update()
    {
        if (Reload < ReloadingTime)
        {
            Enemy.GetComponent<EnemyBehaviour>().EnemyHealth -= Damage;
            Debug.Log("Doing Damage");
        }

        ReloadingTime += Time.deltaTime;
    }

    void FindTarget()
    {
        if(Enemy)
        {
            this.Distance = Vector3.Distance(Enemy.transform.position, transform.position);
            Debug.Log("Target Found");
        }
        else if (HeavyEnemy)
        {
            this.Distance = Vector3.Distance(HeavyEnemy.transform.position, transform.position);
        }
        else if (SmallEnemy)
        {
            this.Distance = Vector3.Distance(SmallEnemy.transform.position, transform.position);
        }
    }

    void AttackTarget()
    {
        //if()
        {
           
        }
    }


}
