using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyScript : MonoBehaviour
{
    public TowerPlacement money;

    [SerializeField]
    TMP_Text text;

    // Start is called before the first frame update
    void Start()
    {
        money = GameObject.Find("Placement").GetComponent<TowerPlacement>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "$ : " + GameObject.Find("Placement").GetComponent<TowerPlacement>().totalMoney;
    }
}
