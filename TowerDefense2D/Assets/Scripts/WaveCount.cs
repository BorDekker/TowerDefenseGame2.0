using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaveCount : MonoBehaviour
{
    public int waveCount;

    [SerializeField]
    TMP_Text text;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        waveCount = GameObject.Find("EnemySpawner").GetComponent<EnemySpawner>().waveCount;
        text.text = "Wave : " + waveCount;
    }
}
