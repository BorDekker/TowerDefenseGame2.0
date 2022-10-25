using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBehaviour : MonoBehaviour
{
    public List<GameObject> Enemies;
    float EnemyLifeTime;

    public int EnemiesKilled;

    GameObject TargetEnemy;

    public float Distance;

    public int Damage;

    [SerializeField]
    public float Reload;

    [SerializeField]
    public float ReloadingTime = 0.5f;

    [SerializeField]
    int killsToUpgrade;

    public GameObject UpgradeTower;

    public int towerCost;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision && collision.gameObject.transform.tag == "Enemy")// Kijkt of de tag van de collider "Enemy" is
        {
            Enemies.Add(collision.gameObject);//Voegt de enemy to aan de list Enemies
        }
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
                    if(EnemiesKilled >= killsToUpgrade)
                    {
                        Instantiate(UpgradeTower, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
                        Destroy(gameObject);
                    }
                }
                ReloadingTime = 0;
                TargetEnemy.GetComponent<EnemyBehaviour>().EnemyHealth -= Damage;
                if (TargetEnemy.GetComponent<EnemyBehaviour>().EnemyHealth <= 0)
                {
                    EnemiesKilled++;
                }
                TargetEnemy = null;
                Debug.Log("Doing Damage");
            }
        }
        ReloadingTime += Time.deltaTime;
    }
}
