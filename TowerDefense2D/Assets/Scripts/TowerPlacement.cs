using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlacement : MonoBehaviour
{
    [SerializeField]
    private Camera mainCamera;

    [SerializeField]
    GameObject towerPosition;

    [SerializeField]
    GameObject selectedTower;

    bool currsorTower;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mouseWorldPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);

        mouseWorldPosition.z = 0;
        transform.position = mouseWorldPosition;

        if(Input.GetKeyDown(KeyCode.Mouse0) && currsorTower)
        {
            Debug.Log(towerPosition.name);
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
            Debug.Log("movement");
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
