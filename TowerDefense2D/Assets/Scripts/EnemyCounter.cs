using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyCounter : MonoBehaviour
{
    public int enemyCounter;

    public TMP_Text enemyCountertxt;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int enemyCounter = GameObject.FindGameObjectsWithTag("Enemy").Length;

        enemyCountertxt.text = ": " + enemyCounter;
    }
}
