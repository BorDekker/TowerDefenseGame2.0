using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBehaviour : MonoBehaviour
{
    public List<GameObject> Enemies;
    float EnemyLifeTime;

    public List<GameObject> EnemiesKilled;

    GameObject TargetEnemy;

    public float Distance;

    public int Damage;

    [SerializeField]
    public float Reload;

    [SerializeField]
    public float ReloadingTime = 0.5f;

    public Sprite Version1Level2;
    public Sprite Version1Level3;

    public Sprite Version2Level2;
    public Sprite Version2Level3;

    public Sprite Version3Level2;
    public Sprite Version3Level3;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision && collision.gameObject.transform.tag == "Enemy")// Kijkt of de tag van de collider "Enemy" is
        {
            Enemies.Add(collision.gameObject);//Voegt de enemy to aan de list Enemies

            //UpgradeTower();
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

    void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject);
        if (collision && collision.gameObject.transform.tag == "Enemy") //Remove enemy wanneer het uit Tower range is
        {
            Enemies.Remove(collision.gameObject);
        }

    }

    private void Update()
    {
        if (Enemies.Count != 0)//Deze code doet damage aan de enemy die het verst weg is.
        {
            if (Reload < ReloadingTime)
            {
                EnemyLifeTime = 0;
                for (int i = 0; i < Enemies.Count; i++)
                {
                    if (Enemies[i] == null)
                    {
                        Enemies.Remove(Enemies[i]);
                    }
                    else if (Enemies[i].GetComponent<EnemyBehaviour>().EnemyLifeTime > EnemyLifeTime)
                    {
                        EnemyLifeTime = Enemies[i].GetComponent<EnemyBehaviour>().EnemyLifeTime;
                        TargetEnemy = Enemies[i];
                    }
                }
                ReloadingTime = 0;
                TargetEnemy.GetComponent<EnemyBehaviour>().EnemyHealth -= Damage;
                TargetEnemy = null;
                Debug.Log("Doing Damage");
            }

        }

        ReloadingTime += Time.deltaTime;

        //UpgradeTower();
    }

    /*
    void UpgradeTower()
    {
        if (EnemiesKilled.Count != 0)
        {
            for (int i = 0; i = EnemiesKilled; i++)
            {
                if (GetComponent<EnemyBehaviour>().EnemyHealth <= 0)
                {
                    Enemies.Add(EnemiesKilled[i]);
                }
            }
        }
    }
    */
    void FindTarget()
    {
            //Debug.Log("Target Found");
        /*
        if(Enemy)
        {
            this.Distance = Vector3.Distance(Enemy.transform.position, transform.position);
        }
        else if (HeavyEnemy)
        {
            this.Distance = Vector3.Distance(HeavyEnemy.transform.position, transform.position);
        }
        else if (SmallEnemy)
        {
            this.Distance = Vector3.Distance(SmallEnemy.transform.position, transform.position);
        }
        
        */
    }

    void AttackTarget()
    {
        //if()
        {
           
        }
    }

}
