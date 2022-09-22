using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBehaviour : MonoBehaviour
{
    public GameObject Enemy;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision)
        {
            DestroyTarget();
        }
        Debug.Log("Target Confirmed");
    }

    void DestroyTarget()
    {
        Destroy(this.Enemy);
        Debug.Log("Target Elliminated");
    }
}
