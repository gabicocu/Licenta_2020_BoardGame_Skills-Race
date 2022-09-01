using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P2SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    private float spawnRangeX = 20;
    private float spawnPosZ = P2PlayerController.z + 20;
    private float startDelay = 2;
    private float spawnInterval = 1.5f;
    // Start is called before the first frame update
    void Start()
    {

        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval);
        
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.S))
        {
            SpawnRandomAnimal();
        }
        */
    }

    void SpawnRandomAnimal()
    {
        if ((Stone.player1Turn && Stone.game && Stone.game2Turn) || (Stone2.player2Turn && Stone2.game && Stone2.game2Turn) && !MainMenuScript.computer)
        {
            int animalIndex = Random.Range(0, animalPrefabs.Length);
            Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX + P2PlayerController.x, spawnRangeX + P2PlayerController.x), 0, spawnPosZ);
            Instantiate(animalPrefabs[animalIndex], spawnPos,
                animalPrefabs[animalIndex].transform.rotation);
        }
    }
}
