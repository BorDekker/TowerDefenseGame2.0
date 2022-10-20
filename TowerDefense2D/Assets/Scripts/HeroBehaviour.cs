using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroBehaviour : MonoBehaviour
{
    public List<GameObject> Enemies;
    float EnemyLifeTime;

    GameObject targetEnemy;

    public float HeroSpeed = 5f;

    private Vector3 Target;

    public float heroDistance;

    public int heroDamage;

    [SerializeField]
    public float heroReload;

    [SerializeField]
    public float heroReloadingTime = 0.5f;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision && collision.gameObject.transform.tag == "Enemy")
        {
            Enemies.Add(collision.gameObject);
        }    
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject);
        if (collision && collision.gameObject.transform.tag == "Enemy")
        {
            Enemies.Remove(collision.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Target = transform.position;
    }

    // Update is called once per frame
    private void Update()
    {
        if (Enemies.Count != 0)//Hero doet damage aan enemy die het verst weg is.
        {
            if (heroReload < heroReloadingTime)
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
                        targetEnemy = Enemies[i];
                    }
                }
                heroReloadingTime = 0;
                targetEnemy.GetComponent<EnemyBehaviour>().EnemyHealth -= heroDamage;
                targetEnemy = null;
                Debug.Log("Hero Doing Damage");
            }

        }

        heroReloadingTime += Time.deltaTime;

        if (Input.GetMouseButtonDown(1))
        {
            Target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Target.z = transform.position.z;
        }

        transform.position = Vector3.MoveTowards(transform.position, Target, HeroSpeed * Time.deltaTime);
    }
}
