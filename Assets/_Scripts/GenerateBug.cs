using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateBug : MonoBehaviour
{
    public GameObject bugPrefab;
    private float respawnTime = 5.0f;
    private Vector3 screenBounds;
    public bool gameStarted; // move this to another script probably later

    // Start is called before the first frame update
    void Start()
    {
        gameStarted = true;
        StartCoroutine(bugCreation());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void spawnBug()
    {
        GameObject b = Instantiate(bugPrefab) as GameObject;
        float x = UnityEngine.Random.Range(-25, 25);
        float y = UnityEngine.Random.Range(1, 15);
        float z = UnityEngine.Random.Range(-25, 25);
        b.transform.position = new Vector3(x, y, z);
    }

    IEnumerator bugCreation()
    {
        while (gameStarted)
        {
            yield return new WaitForSeconds(respawnTime);
            spawnBug();
            Debug.Log("bug created");
        }
        

    }
}

// from tutorial: https://www.youtube.com/watch?v=E7gmylDS1C4&ab_channel=PressStart
