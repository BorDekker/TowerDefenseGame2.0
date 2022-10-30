using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{
    public GameObject TowerPrefab;
    public GameObject PlaceTower;
    public void TowerButtons()
    {
        PlaceTower.GetComponent<TowerPlacement>().selectedTower = TowerPrefab;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Placement").GetComponent<TowerPlacement>().totalMoney < TowerPrefab.GetComponent<TowerBehaviour>().towerCost)
        {
            gameObject.GetComponent<Image>().color = Color.red;
        }
        else
        {
            gameObject.GetComponent<Image>().color = Color.white;
        }
    }
}
