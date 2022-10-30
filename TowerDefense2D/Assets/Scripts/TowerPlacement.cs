using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TowerPlacement : MonoBehaviour
{
    [SerializeField]
    private Camera mainCamera;

    [SerializeField]
    GameObject towerPosition;

    public GameObject selectedTower;

    public int totalMoney;

    bool currsorTower;

    public bool isColorActive;
    public float timeColorIsActive;

    [SerializeField]
    TMP_Text Button1text;
    // Start is called before the first frame update
    void Start()
    {
        isColorActive = true;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mouseWorldPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);

        mouseWorldPosition.z = 0;
        transform.position = mouseWorldPosition;

        if (Input.GetKeyDown(KeyCode.Mouse0) && currsorTower && totalMoney >= selectedTower.GetComponent<TowerBehaviour>().towerCost && selectedTower.GetComponent<TowerBehaviour>().towerOnItsRightFullPlace == towerPosition.transform.name)
        {
            Debug.Log(towerPosition.name);
            totalMoney -= selectedTower.GetComponent<TowerBehaviour>().towerCost;
            Instantiate(selectedTower, new Vector3(towerPosition.transform.position.x, towerPosition.transform.position.y, towerPosition.transform.position.z), Quaternion.identity);
            Destroy(towerPosition);
            towerPosition = null;
            currsorTower = false;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.transform.tag == "PlaceTower")
        {
            towerPosition = collision.gameObject;
            currsorTower = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.transform.tag == "PlaceTower")
        {
            currsorTower = false;
            towerPosition = null;
        }
    }
}
