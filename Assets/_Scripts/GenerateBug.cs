using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateBug : MonoBehaviour
{
    public GameObject bugPrefab;
    private float respawnTime = 20.0f;
    private Vector3 screenBounds;
    public bool gameStarted; // move this to another script probably later

    // Start is called before the first frame update
    void Start()
    {
        gameStarted = true; // player has started game
        StartCoroutine(bugCreation()); // start bug creation, which will keep running as long as player is playing
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void spawnBug()
    {
        // instantiate bug prefab
        GameObject b = Instantiate(bugPrefab) as GameObject; 

        // set a random spawn location for the bug within the bounds of the environment
        float x = UnityEngine.Random.Range(-25, 25);
        float y = UnityEngine.Random.Range(1, 15);
        float z = UnityEngine.Random.Range(-25, 25);
        b.transform.position = new Vector3(x, y, z);
    }

    IEnumerator bugCreation()
    {
        // while the game is being played
        while (gameStarted)
        {
            // wait respawn time (15 seconds) then spawn a new bug
            yield return new WaitForSeconds(respawnTime);
            spawnBug();
        }
        

    }
}

// from tutorial: https://www.youtube.com/watch?v=E7gmylDS1C4&ab_channel=PressStart
